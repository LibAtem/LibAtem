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

            _output.WriteLine(string.Join("\n", failures));
            Assert.Empty(failures);
        }
        
        private static void TestSingle(Type t)
        {
            ICommand raw = (ICommand)Activator.CreateInstance(t);
            var state = new AtemState();
            AtemStateBuilder.Update(state, new TopologyV8Command()
            {
                MediaPlayers = 2,
                MixEffectBlocks = 2,
                ColorGenerators = 2,
                Auxiliaries = 2,
                SuperSource = 2,
            });
            AtemStateBuilder.Update(state, new SuperSourceConfigV8Command
            {
                SSrcId = 0,
                Boxes = 4
            });
            AtemStateBuilder.Update(state, new MixEffectBlockConfigCommand
            {
                Index = 0,
                KeyCount = 2,
            });
            AtemStateBuilder.Update(state, new MediaPoolConfigCommand
            {
                ClipCount = 2,
                StillCount = 10
            });
            
            AtemStateBuilder.Update(state, raw);
        }
    }
}