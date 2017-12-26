using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LibAtem.MacroOperations;
using LibAtem.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.XmlState.Test
{
    public class TestMacroOp
    {
        private readonly ITestOutputHelper output;

        public TestMacroOp(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestMacros1()
        {
            RunForFile("TestMacroFiles/macros1.macros", "TestMacroFiles/macros1.xml");
        }

        [Fact]
        public void TestFlyKey()
        {
            RunForFile("TestMacroFiles/flykey.macros", "TestMacroFiles/flykey.xml");
        }

        [Fact]
        public void TestAudio()
        {
            RunForFile("TestMacroFiles/audio.macros", "TestMacroFiles/audio.xml");
        }

        #region Helpers

        private void RunForFile(string byteFilename, string xmlFilename)
        {
            XmlState xmlSpec = XmlStatePersistor.LoadState(xmlFilename);
            Assert.NotNull(xmlSpec);

            bool failed = false;

            using (StreamReader byteFile = new StreamReader(byteFilename))
            {
                while (!byteFile.EndOfStream)
                {
                    string[] parts = byteFile.ReadLine().Split(": ");
                    Assert.Equal(2, parts.Length);

                    int index = int.Parse(parts[0]);
                    int count = int.Parse(parts[1]);

                    Macro macroXml = xmlSpec.MacroPool.FirstOrDefault(m => m.Index == index);
                    Assert.NotNull(macroXml);

                    List<byte[]> data = Enumerable.Range(0, count).Select(x => StringToByteArray(byteFile.ReadLine())).ToList();

                    Assert.Equal(macroXml.Operations.Count, data.Count);

                    for (var i = 0; i < count; i++)
                    {
                        try
                        {
                            MacroOpBase converted = MacroOpManager.CreateFromData(data[i]);
                            MacroOpBase op = macroXml.Operations[i].ToMacroOp();
                            if (!Equals(converted, op))
                            {
                                output.WriteLine("Got:\n {0}Expected:\n {1}", ToString(converted), ToString(op));
                                failed = true;
                            }
                        }
                        catch (Exception e)
                        {
                            output.WriteLine(e.Message + "\n");
                            failed = true;
                        }
                    }
                }
            }

            Assert.False(failed);
        }

        private static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace("-", "");
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        private static bool Equals(MacroOpBase x, MacroOpBase y)
        {
            if (x == null || y == null)
                return false;

            if (x.GetType() != y.GetType())
                return false;

            AutoSerializeBase.CommandPropertySpec info = AutoSerializeBase.GetPropertySpecForType(x.GetType());

            foreach (var prop in info.Properties)
            {
                object xVal = prop.Getter.DynamicInvoke(x);
                object yVal = prop.Getter.DynamicInvoke(y);
                if (Equals(xVal, yVal))
                    continue;

                if (prop.PropInfo.PropertyType == typeof(double) && Math.Abs((double)xVal - (double)yVal) <= 0.001)
                    continue;

                return false;
            }

            return true;
        }

        private static string ToString(MacroOpBase op)
        {
            AutoSerializeBase.CommandPropertySpec info = AutoSerializeBase.GetPropertySpecForType(op.GetType());

            var sb = new StringBuilder();
            sb.Append(op.GetType().Name);
            sb.Append(":\n");

            foreach (var prop in info.Properties)
                sb.AppendFormat("    {0}={1}\n", prop.PropInfo.Name, prop.Getter.DynamicInvoke(op));

            return sb.ToString();
        }

        #endregion Helpers
    }
}