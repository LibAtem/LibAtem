using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibAtem.State
{
    [Serializable]
    public class AtemState
    {
        public IReadOnlyList<AuxState> Auxiliaries { get; set; } = new List<AuxState>();
        public IReadOnlyList<ColorState> ColorGenerators { get; set; } = new List<ColorState>();

        public IReadOnlyList<DownstreamKeyerState> DownstreamKeyers { get; set; } = new List<DownstreamKeyerState>();
        public IReadOnlyList<MediaPlayerState> MediaPlayers { get; set; } = new List<MediaPlayerState>();
        public IReadOnlyList<MixEffectState> MixEffects { get; set; } = new List<MixEffectState>();
        public IReadOnlyList<SuperSourceState> SuperSources { get; set; } = new List<SuperSourceState>();
        public IReadOnlyList<HyperdeckState> Hyperdecks { get; set; } = new List<HyperdeckState>();

        public AudioState Audio { get; set; }
        public FairlightAudioState Fairlight { get; set; }

        public CameraControlState CameraControl { get; } = new CameraControlState();

        public DisplayClockState DisplayClock { get; set; }

        public MacroState Macros { get; } = new MacroState();
        public MediaPoolState MediaPool { get; } = new MediaPoolState();
        public SettingsState Settings { get; } = new SettingsState();

        public StreamingState Streaming { get; set; }
        public RecordingState Recording { get; set; }

        public InfoState Info { get; } = new InfoState();

        public AudioRoutingState AudioRouting { get; set; }

        public bool[] Power { get; set; } = { false };

        #region Clone
        public AtemState Clone()
        {
            return DeepCopyReflection(this);
        }
        private static T DeepCopyReflection<T>(T input)
        {
            if (input != null && input.GetType().IsClass && !input.GetType().FullName.StartsWith("System."))
            {
                T clonedObj = (T)Activator.CreateInstance(input.GetType());
                DeepCopyReflectionValue(clonedObj, input);
                return clonedObj;
            }
            else
            {
                return input;
            }
        }

        public static T DeepCopyReflectionValue<T>(T clonedObj, T input)
        {
            var type = input.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (!property.CanRead) continue;

                bool isDictionary = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Dictionary<,>);
                bool isList = property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(List<>) || property.PropertyType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>));
                if (isDictionary)
                {
                    dynamic oldDict = Convert.ChangeType(property.GetValue(input), property.PropertyType);
                    if (oldDict != null)
                    {
                        var newVal = property.GetValue(clonedObj);
                        if (newVal == null)
                        {
                            newVal = Activator.CreateInstance(property.PropertyType);
                            property.SetValue(clonedObj, newVal);
                        }


                        dynamic newDict = Convert.ChangeType(newVal, property.PropertyType);

                        foreach (dynamic oldInner in oldDict)
                        {
                            newDict[oldInner.Key] = DeepCopyReflection(oldInner.Value);
                        }
                    }
                }
                else if (isList)
                {
                    Type itemType = property.PropertyType.GetGenericArguments()[0];
                    Type[] genericTypes = { itemType };
                    Type listType = typeof(List<>).MakeGenericType(genericTypes);

                    dynamic oldList = property.GetValue(input);
                    if (oldList != null)
                    {
                        dynamic newList = Activator.CreateInstance(listType);
                        property.SetValue(clonedObj, newList);

                        for (int i = 0; i < oldList.Count; i++)
                        {
                            newList.Add(DeepCopyReflection(oldList[i]));
                        }
                    }
                }
                else
                {

                    object value = property.GetValue(input);
                    if (property.CanWrite)
                    {
                        property.SetValue(clonedObj, value);
                    }
                    else if (value != null)
                    {
                        var target = property.GetValue(clonedObj);
                        if (target == null)
                        {
                            throw new Exception("Not supported or something");
                        }

                        DeepCopyReflectionValue(target, value);
                    }
                }
            }
            return clonedObj;
        }

        #endregion Clone
    }
}