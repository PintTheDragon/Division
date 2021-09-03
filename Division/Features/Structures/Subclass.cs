using System.Collections.Generic;
using System.ComponentModel;
using Division.Features.Structures.Configs;
using Exiled.API.Enums;

namespace Division.Features.Structures
{
    public class Subclass
    {
        public bool IsEnabled { get; set; } = true;
        public string Name { get; set; } = "Subclass";
        
        [Description] public AppearanceOptions AppearanceOptions { get; set; } = new AppearanceOptions();
        [Description] public MessageOptions MessageOptions { get; set; } = new MessageOptions();
        [Description] public SpawnOptions SpawnOptions { get; set; } = new SpawnOptions();
        [Description] public Inventory Inventory { get; set; } = new Inventory();
        [Description] public Dictionary<AmmoType, ushort> Ammo { get; set; } = new Dictionary<AmmoType, ushort> { { AmmoType.Nato9, 100 } };
    }
}