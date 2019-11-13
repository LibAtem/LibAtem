using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LibAtem.Serialization;
using Xunit;

namespace LibAtem.Test.Util
{
    public class RandomPropertyGenerator
    {
        public static readonly Random random = new Random();

        public static object Create(Type t)
        {
            return Create(t, (o) => true);
        }

        public static object Create(Type t, Func<object, bool> enumIsValid)
        {
            object cmd = Activator.CreateInstance(t);
            foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                // If prop cannot be deserialized, then ignore
                if (!prop.CanWrite || prop.GetSetMethod() == null)
                    continue;

                if (prop.GetCustomAttribute<NoSerializeAttribute>() != null)
                    continue;

                // Generate random prop value
                IRandomGeneratorAttribute attr = prop.GetCustomAttributes().OfType<IRandomGeneratorAttribute>().FirstOrDefault();
                if (attr != null)
                {
                    prop.SetValue(cmd, attr.GetRandom(random));
                    continue;
                }

                // If prop is an enum, then take a random value
                if (prop.PropertyType.GetTypeInfo().IsEnum)
                {
                    object[] values = Enum.GetValues(prop.PropertyType).OfType<object>().Where(enumIsValid).ToArray();
                    prop.SetValue(cmd, values.GetValue(random.Next(values.Length)));
                    continue;
                }

                Assert.True(false, string.Format("Missing generator attribute for property: {0}", prop.Name));
            }
            return cmd;
        }

        public static void AssertAreTheSame(object orig, object decoded)
        {
            PropertyInfo[] props = orig.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetCustomAttribute<NoSerializeAttribute>() != null)
                    continue;

                object origVal = prop.GetValue(orig);
                object decodedVal = prop.GetValue(decoded);

                SerializableAttributeBase attr = prop.GetCustomAttribute<SerializableAttributeBase>();
                if (attr != null)
                {
                    Assert.True(attr.AreEqual(origVal, decodedVal), 
                        string.Format("{0}.{1} does not match. Orig:{2}, Decoded:{3}", orig.GetType().Name, prop.Name, origVal, decodedVal));
                    continue;
                }

                Assert.True(Equals(origVal, decodedVal),
                    string.Format("{0}.{1} does not match. Orig:{2}, Decoded:{3}", orig.GetType().Name, prop.Name, origVal, decodedVal));
            }
        }

        public static bool AreTheSame(object orig, object decoded, bool allowedNoProps)
        {
            int comparedProps = 0;

            PropertyInfo[] props = orig.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetCustomAttribute<NoSerializeAttribute>() != null)
                    continue;

                comparedProps++;

                object origVal = prop.GetValue(orig);
                object decodedVal = prop.GetValue(decoded);

                SerializableAttributeBase attr = prop.GetCustomAttribute<SerializableAttributeBase>();
                if (attr != null)
                {
                    if (!attr.AreEqual(origVal, decodedVal))
                        return false;

                    continue;
                }

                Type t = prop.PropertyType;
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    dynamic origDict = Convert.ChangeType(origVal, t);
                    dynamic decodedDict = Convert.ChangeType(decodedVal, t);

                    var origKeys = new List<object>();
                    foreach (dynamic v in origDict)
                        origKeys.Add(v.Key);
                    
                    var decodedKeys = new List<object>();
                    foreach (dynamic v in decodedDict)
                        decodedKeys.Add(v.Key);
                    
                    origKeys.Sort();
                    decodedKeys.Sort();
                    if (!origKeys.SequenceEqual(decodedKeys))
                        return false;

                    var origVals = new List<object>();
                    var decodedVals = new List<object>();

                    foreach (dynamic k in origKeys)
                    {
                        origVals.Add(origDict[k]);
                        decodedVals.Add(decodedDict[k]);
                    }

                    if (!origVals.SequenceEqual(decodedVals))
                        return false;
                    
                    continue;
                }
                
                if (origVal is IEnumerable enumVal)
                {
                    List<object> origList = enumVal.OfType<object>().ToList();
                    List<object> decodedList = ((IEnumerable) decodedVal).OfType<object>().ToList();
                    if (!origList.SequenceEqual(decodedList))
                        return false;

                    continue;
                }
                
                if (!Equals(origVal, decodedVal))
                    return false;
            }

            return allowedNoProps || comparedProps > 0;
        }
    }
}
