using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibAtem.Commands;
using LibAtem.Commands.DeviceProfile;
using LibAtem.State.Builder;
using Xunit;
using Xunit.Abstractions;

namespace LibAtem.State.Test
{
    public class TestStateBuilderProperties
    {
        private readonly ITestOutputHelper _output;

        public TestStateBuilderProperties(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestClone()
        {
            var state = new AtemState();
            // Simply ensure it can be cloned, as it relies on all classes having an attribute
            state.Clone();
        }
        
        [Fact]
        public void TestStateUpdaterProperties()
        {
            Assert.True(AtemStateBuilder.IsDebug(), "State lib needs to be debug to have the check compiled");
            
            var failures = new List<string>();

            Assembly assembly = typeof(ICommand).GetTypeInfo().Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => typeof(SerializableCommandBase).GetTypeInfo().IsAssignableFrom(t));
            foreach (Type type in types)
            {
                if (type == typeof(SerializableCommandBase))
                    continue;

                var attr = type.GetCustomAttribute<CommandNameAttribute>();
                if (attr == null || attr.Direction == CommandDirection.ToServer)
                    continue;

                try
                {
                    // output.WriteLine("Testing: {0}", type.Name);
                    TestSingle(type);
                }
                catch (Exception e)
                {
                    failures.Add($"{type.Name}: {e.Message} {e.StackTrace}");
                }
            }

            _output.WriteLine(string.Join("\n\n", failures));
            Assert.Empty(failures);
        }

        private void DoUpdate(AtemState state, ICommand cmd)
        {
            var res = AtemStateBuilder.Update(state, cmd);

            if (res.Errors.Count > 0)
            {
                _output.WriteLine("Failed: {0} {1}\n", cmd.GetType().FullName, string.Join('\n', res.Errors));
            }
            Assert.Equal(0, res.Errors.Count);

            if (!res.Success)
                throw new Exception("State update was not successful");
        }
        
        private void TestSingle(Type t)
        {
            ICommand raw = (ICommand)Activator.CreateInstance(t);
            var state = new AtemState();
            DoUpdate(state, new TopologyV8Command()
            {
                MediaPlayers = 2,
                MixEffectBlocks = 2,
                DownstreamKeyers = 2,
                Auxiliaries = 2,
                SuperSource = 2,
                HyperDecks = 2,
                MixMinusOutputs = 24,
            });
            DoUpdate(state, new SuperSourceConfigV8Command
            {
                SSrcId = 0,
                Boxes = 4
            });
            DoUpdate(state, new MixEffectBlockConfigCommand
            {
                Index = 0,
                KeyCount = 2,
            });
            DoUpdate(state, new MediaPoolConfigCommand
            {
                ClipCount = 2,
                StillCount = 10
            });
            DoUpdate(state, new AudioMixerConfigCommand
            {
                Monitors = 1,
                Inputs = 10
            });
            DoUpdate(state, new MultiviewerConfigV8Command
            {
                Count = 1,
                WindowCount = 10
            });
            DoUpdate(state, new MacroPoolConfigCommand
            {
                MacroCount = 10
            });

            // TODO - this should be done to provide a strict test that everything gets applied to the state correctly
            DoUpdate(state, raw);
            AtemStateBuilder.Update(state, raw);
        }
    }
}