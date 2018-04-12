using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using LibAtem.Commands;
using LibAtem.Commands.Macro;
using LibAtem.Net;
using LibAtem.Net.DataTransfer;
using LibAtem.Util;

namespace LibAtem.XmlState.TestMacroOpsGenerate
{
    class SaveMacrosToFile
    {
        private List<MacroPropertiesGetCommand> _macros;
        private AtemClient _client;
        private StreamWriter _file;

        static void Main(string[] args)
        {
            string filename = "output.macros";

            new SaveMacrosToFile().Run("10.42.13.99", filename);
        }

        public void Run(string address, string filename)
        {
            _file = new StreamWriter(filename);

            _macros = new List<MacroPropertiesGetCommand>();
            _client = new AtemClient(address, false);

            _client.OnReceive += OnCommand;
            _client.Connect();

            Console.ReadLine();
        }

        private void DownloadMacros()
        {
            new Thread(() =>
            {
                Console.WriteLine(string.Format("Downloading {0} macros", _macros.Count));
                foreach (MacroPropertiesGetCommand macro in _macros.ToList())
                {
                    if (!macro.IsUsed)
                        continue;

                    IReadOnlyList<byte[]> result = null;
                    var evt = new AutoResetEvent(false);

                    var job = new DownloadMacroBytesJob(macro.Index, ops =>
                    {
                        result = ops;
                        evt.Set();
                    }, TimeSpan.FromMilliseconds(5000));

                    _client.DataTransfer.QueueJob(job);

                    bool res = evt.WaitOne(TimeSpan.FromMilliseconds(5000));
                    if (!res)
                        throw new Exception("Timed out");

                    if (result == null)
                        throw new Exception("No result");

                    _file.WriteLine(string.Format("{0}: {1}", macro.Index, result.Count));
                    foreach (byte[] l in result)
                        _file.WriteLine(BitConverter.ToString(l));
                }

                _file.Close();
                _client.Dispose();
                Environment.Exit(0);
            }).Start();
        }

        private void OnCommand(object sender, IReadOnlyList<ICommand> commands)
        {
            foreach (ICommand cmd in commands)
            {
                if (cmd is MacroPropertiesGetCommand)
                    _macros.AddIfNotNull(cmd as MacroPropertiesGetCommand);
                if (cmd is InitializationCompleteCommand)
                    DownloadMacros();
            }
        }
    }
}
