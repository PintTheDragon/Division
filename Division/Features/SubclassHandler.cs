using System.Collections.Generic;
using Division.Features.Structures;
using Exiled.API.Features;

namespace Division.Features
{
    public static class SubclassHandler
    {
        public static Dictionary<Player, Subclass> PlayerSubclasses = new Dictionary<Player, Subclass>();
        public static Dictionary<string, Subclass> EnabledSubclasses = new Dictionary<string, Subclass> ();
        public static Dictionary<RoleType, List<Subclass>> OrderedSubclasses = new Dictionary<RoleType, List<Subclass>>();
        
        // The current version is almost empty
    }
}