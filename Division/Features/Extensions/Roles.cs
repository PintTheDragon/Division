using Division.Features.Structures;
using UnityEngine;

namespace Division.Features.Extensions
{
    public static class Roles
    {
        public static Subclass GetSubclass(this RoleType role) => SubclassHandler.OrderedSubclasses.ContainsKey(role) ? SubclassHandler.OrderedSubclasses[role][Random.Range(0, SubclassHandler.OrderedSubclasses[role].Count)] : null;
    }
}