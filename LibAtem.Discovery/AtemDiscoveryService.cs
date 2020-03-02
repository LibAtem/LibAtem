using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Makaretu.Dns;

namespace LibAtem.Discovery
{
    public class AtemDiscoveryService
    {
        private readonly bool _debug;
        private readonly Dictionary<string, AtemDeviceInfo> _knownDevices;
        private readonly MulticastService _mdns;

        private Timer _updateTimer;

        public delegate void DeviceHandler(object sender, AtemDeviceInfo device);

        public event DeviceHandler OnDeviceSeen;
        public event DeviceHandler OnDeviceLost;

        public AtemDiscoveryService(int updatePeriod = 10000, bool debug = false)
        {
            _debug = debug;
            _knownDevices = new Dictionary<string, AtemDeviceInfo>();

            _mdns = new MulticastService();
            _mdns.UseIpv4 = true;
            _mdns.UseIpv6 = false;
            _mdns.NetworkInterfaceDiscovered += (s, e) => SendQuery();
            _mdns.AnswerReceived += (s, e) => AnswerReceived(e.Message);
            _mdns.Start();

            _updateTimer = new Timer(a => {
                DateTime now = DateTime.Now;

                lock (_knownDevices)
                {
                    List<string> ids = _knownDevices.Keys.ToList();
                    foreach (string id in ids)
                    {
                        AtemDeviceInfo dev = _knownDevices[id];
                        // Remove if not seen in too long
                        if (dev != null && now.Subtract(dev.LastSeen).TotalMilliseconds > updatePeriod * 3)
                        {
                            _knownDevices.Remove(id);
                            OnDeviceLost?.Invoke(this, dev);
                        }
                    }
                }

                SendQuery();
            }, null, updatePeriod, updatePeriod);
        }

        private void SendQuery()
        {
            if (_debug) Console.WriteLine("Send Query");
            _mdns.SendQuery(AtemDeviceInfo.ServiceName);
        }

        private void AnswerReceived(Message message)
        {
            List<PTRRecord> answers = message.Answers.Where(a => a.Name == AtemDeviceInfo.ServiceName).OfType<PTRRecord>().ToList();
            PTRRecord answer = answers.FirstOrDefault();
            if (answer == null)
                return;

            if (_debug && answers.Count != 1) Console.WriteLine("Too many answers!");

            List<ResourceRecord> records = message.AdditionalRecords;
            SRVRecord srvRec = records.OfType<SRVRecord>().FirstOrDefault(r => r.Type == DnsType.SRV && r.Name == answer.DomainName);
            if (srvRec == null)
            {
                if (_debug) Console.WriteLine("Missing SRV record for " + answer.DomainName);
                return;
            }

            AddressRecord aRec = records.OfType<AddressRecord>().FirstOrDefault(r => r.Type == DnsType.A && r.Name == srvRec.Target);
            if (srvRec == null)
            {
                if (_debug) Console.WriteLine("Missing A record for " + answer.DomainName);
                return;
            }

            TXTRecord txtRec = records.OfType<TXTRecord>().FirstOrDefault(r => r.Type == DnsType.TXT && r.Name == answer.DomainName);
            List<string> strings = txtRec == null ? new List<string>() : txtRec.Strings;

            string name = answer.DomainName;
            if (name.EndsWith(AtemDeviceInfo.ServiceName))
                name = name.Substring(0, name.Length - AtemDeviceInfo.ServiceName.Length - 1);

            var dev = new AtemDeviceInfo(name, srvRec.Target, DateTime.Now, aRec.Address.ToString(), srvRec.Port, strings);

            lock (_knownDevices) {
                _knownDevices[dev.DeviceId] = dev;
            }

            OnDeviceSeen?.Invoke(this, dev);
        }

        public void Stop()
        {
            _mdns.Stop();

            try
            {
                _updateTimer.Dispose();
            }
            finally
            {
                _updateTimer = null;
            }

            lock (_knownDevices)
            {
                _knownDevices.Clear();
            }
        }

        public List<AtemDeviceInfo> GetDevices()
        {
            lock(_knownDevices)
            {
                return _knownDevices.Select(d => d.Value).ToList();
            }
        }
    }
}
