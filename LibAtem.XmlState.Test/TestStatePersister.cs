using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using FatAntelope;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.XmlState.Test
{
    /// <summary>
    ///  Test that opening and saving various xml files exported from the atem software client can be done and without any changes to the xml
    /// </summary>
    public class TestStatePersister
    {
        private readonly ITestOutputHelper output;

        public TestStatePersister(ITestOutputHelper output)
        {
            this.output = output;
        }

        // Fields added at various file versions (<version, new_fields)
        private static readonly Dictionary<int, string[]> AddedFields = new Dictionary<int, string[]>()
        {
            {
                CalculateFileVersion(1, 4), new[]
                {
                   ".Profile.Settings.MultiViews.MultiView.vuMeterOpacity",
                   ".Profile.Settings.MultiViews.MultiView.safeAreaEnabled",
                   ".Profile.Settings.MultiViews.MultiView.programPreviewSwapped",
                   ".Profile.Settings.MultiViews.MultiView.Windows.Window.vuMeterEnabled",
                   ".Profile.Settings.downConvertMode",
                   ".Profile.Settings.SDI3GOutputLevel",
                }
            }
        };

        [Fact]
        public void TestResults2016()
        {
            RunForFile("TestFiles/results2016.xml");
        }

        [Fact]
        public void TestResults2016_2()
        {
            RunForFile("TestFiles/results2016-2.xml");
        }

        [Fact]
        public void TestXplosion2016()
        {
            RunForFile("TestFiles/xplosion2016.xml");
        }

        [Fact]
        public void TestResults2017()
        {
            RunForFile("TestFiles/results2017.xml");
        }

        [Fact]
        public void TestResults2017_2()
        {
            RunForFile("TestFiles/results2017-2.xml");
        }

        [Fact]
        public void TestResults2017_3()
        {
            RunForFile("TestFiles/results2017-3.xml");
        }

        [Fact]
        public void TestAtemProduction4K()
        {
            RunForFile("TestFiles/atem-production-4k.xml");
        }

        [Fact]
        public void TestValefest2017()
        {
            RunForFile("TestFiles/valefest2017.xml");
        }

        #region Helpers

        private void RunForFile(string filename)
        {
            string tmpFile = Path.GetTempFileName();
            string fullPath = Path.Combine(AppContext.BaseDirectory, filename);

            XmlState profile = XmlStatePersistor.LoadState(fullPath);
            Assert.NotNull(profile);
            Assert.True(XmlStatePersistor.SaveState(tmpFile, profile));

            List<string> changes = CompileXmlChanges(CalculateFileVersion(profile.MajorVersion, profile.MinorVersion), fullPath, tmpFile);
            File.Delete(tmpFile);

            string res = String.Join(Environment.NewLine, changes);
            output.WriteLine(res);
            Assert.Equal("", res);
        }

        private static List<String> CompileXmlChanges(int fileVersion, string origPath, string newPath)
        {
            XmlDocument origDoc = new XmlDocument();
            FileStream origFs = new FileStream(origPath, FileMode.Open);
            origDoc.Load(origFs);
            origFs.Dispose();

            XmlDocument newDoc = new XmlDocument();
            FileStream newFs = new FileStream(newPath, FileMode.Open);
            newDoc.Load(newFs);
            newFs.Dispose();

            var tree1 = new XTree(origDoc);
            var tree2 = new XTree(newDoc);
            XDiff.Diff(tree1, tree2);

            var res = new List<String>();

            List<string> missingFromNew = CompileXmlChangesForNode(Enumerable.Empty<string>().ToImmutableHashSet(),"",  "", tree1.Root);
            if (missingFromNew.Any())
            {
                res.Add("Missing nodes:");
                res.AddRange(missingFromNew);
            }

            ImmutableHashSet<string> canIgnore =
                AddedFields.Where(kv => kv.Key >= fileVersion).SelectMany(kv => kv.Value).ToImmutableHashSet();

            List<string> extra = CompileXmlChangesForNode(canIgnore, "", "", tree2.Root);
            if (extra.Any())
            {
                res.Add("Additional nodes:");
                res.AddRange(extra);
            }

            return res;
        }

        private static List<string> CompileXmlChangesForNode(ImmutableHashSet<string> canIgnore, string fqPath, string prefix, XNode node)
        {
            var thisFqPath = fqPath + "." + node.Name;
            switch (node.Match)
            {
                case MatchType.Match:
                    return new List<string>();
                case MatchType.NoMatch:
                    if (canIgnore.Contains(thisFqPath))
                        return new List<string>();

                    return new List<string>() {prefix + "Unexpected " + node.Name };
                case MatchType.Change:
                    break;
                default:
                    Debug.Fail("Unexpected MatchType in XmlDiff");
                    return new List<string>();
            }

            var res = new List<string>();

            foreach (XNode attr in node.Attributes)
            {
                res.AddRange(CompileXmlChangesForNode(canIgnore, thisFqPath, prefix + "  ", attr));
            }

            foreach (XNode ch in node.Children)
            {
                res.AddRange(CompileXmlChangesForNode(canIgnore, thisFqPath, prefix + "  ", ch));
            }

            return res.Any() ? res.Prepend(prefix + node.Name + ":").ToList() : res;
        }

        private static int CalculateFileVersion(int major, int minor)
        {
            return major * 100 + minor;
        }

        #endregion Helpers
    }
}
