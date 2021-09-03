using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Features;
using UnityEngine;

namespace Division.Features.Structures.Configs
{
    public class SpawnOptions
    {
        public List<RoleType> Roles { get; set; } = new List<RoleType> { RoleType.ClassD };
        [Description]
        public Vector3 Scale { get; set; } = Vector3.one;
        public List<RoomType> SpawnRooms { get; set; } = new List<RoomType> { RoomType.Unknown };
        [Description]
        public int Health { get; set; } = -1;
        public int MaxHealth { get; set; } = -1;
        public int Ahp { get; set; } = -1;
        public int MaxAhp { get; set; } = -1;
    }
}