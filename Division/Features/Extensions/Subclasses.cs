using System;
using Division.Features.Structures;
using Exiled.API.Features;
using YamlDotNet.Core;

namespace Division.Features.Extensions
{
    public static class Subclasses
    {
        public static string ToYaml(this Subclass subclass)
        {
            return YamlManager.Serializer.Serialize(subclass);
        }
        
        public static Subclass YamlToSubclass(string yaml, string path = "")
        {
            try
            {
                return YamlManager.Deserializer.Deserialize<Subclass>(yaml);
            }
            catch (YamlException yamlException)
            {
                Log.Error($"Class with path: {path} could not be loaded, Skipping. {yamlException}");
            }
            catch (FormatException e)
            {
                Log.Error($"Class with path: {path} could not be loaded due to a format exception. {e}\nBegin stack trace:\n{e.StackTrace}");
            }
            catch (Exception e)
            {
                Log.Error($"Class with path: {path} could not be loaded. {e}\nBegin stack trace:\n{e.StackTrace}");
            }

            return null;
        }
    }
}