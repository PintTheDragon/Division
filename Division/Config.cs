using System.ComponentModel;
using System.IO;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace Division
{
    public class Config : IConfig
    {
        [Description("This is a pre-release version of Division with 5% of its final content, everything is subject to change.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Global Subclasses Folder")]
        public string GlobalSubclassesFolder { get; set; } = Path.Combine(Paths.Configs, "Division", "Division-Global");
        [Description("This Server Subclasses Folder")]
        public string ServerSubclassesFolder { get; set; } = Path.Combine(Paths.Configs, "Division", $"Division-{Server.Port}");
    }
}