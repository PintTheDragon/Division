using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Division.Features.Extensions;
using Division.Features.Structures;
using Exiled.API.Features;
using Exiled.Loader;
using YamlDotNet.Serialization;

namespace Division.Features
{
    public static class YamlManager
    {
        public static ISerializer Serializer => Loader.Serializer;
        public static IDeserializer Deserializer => Loader.Deserializer;

        public static void LoadPaths()
        {
            if (!Directory.Exists(Path.Combine(Paths.Configs, "Division")))
                Directory.CreateDirectory(Path.Combine(Paths.Configs, "Division"));
                
            if (!Directory.Exists(MainClass.Instance.Config.ServerSubclassesFolder))
                Directory.CreateDirectory(MainClass.Instance.Config.ServerSubclassesFolder);
            
            if (!Directory.Exists(MainClass.Instance.Config.GlobalSubclassesFolder))
            {
                Directory.CreateDirectory(MainClass.Instance.Config.GlobalSubclassesFolder);
                File.WriteAllText(Path.Combine(MainClass.Instance.Config.GlobalSubclassesFolder, "subclass-example.yml"), Subclasses.ToYaml(new Subclass()));
                Log.Debug(Path.Combine(MainClass.Instance.Config.GlobalSubclassesFolder, "subclass-example.yml"));
            }
        }

        public static void LoadSubclasses()
        {
            LoadPaths();

            var paths = GetPaths();

            foreach (var path in paths)
            {
                var subclass = Subclasses.YamlToSubclass(File.ReadAllText(path), path);
                
                if(subclass == null)
                    return;

                if (SubclassHandler.EnabledSubclasses.ContainsKey(subclass.Name))
                {
                    Log.Warn($"The subclass {subclass.Name} cant be enabled because another subclass with the same name was added.");
                    return;
                }

                if (subclass.IsEnabled)
                {
                    SubclassHandler.EnabledSubclasses.Add(subclass.Name, subclass);

                    foreach (var role in subclass.SpawnOptions.Roles)
                    {
                        if(!SubclassHandler.OrderedSubclasses.ContainsKey(role))
                            SubclassHandler.OrderedSubclasses.Add(role, new List<Subclass>());
                        SubclassHandler.OrderedSubclasses[role].Add(subclass);
                    }
                }
            }
        }
        
        private static IEnumerable<string> GetPaths()
        {
            var subclassesFileList = new List<string>();
            subclassesFileList.AddRange(Directory.GetFiles(MainClass.Instance.Config.GlobalSubclassesFolder).Where(file => file.EndsWith(".yml") || file.EndsWith(".yaml")));
            subclassesFileList.AddRange(Directory.GetFiles(MainClass.Instance.Config.ServerSubclassesFolder).Where(file => file.EndsWith(".yml") || file.EndsWith(".yaml")));

            return subclassesFileList;
        }
    }
}