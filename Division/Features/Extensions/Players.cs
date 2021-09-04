using System;
using System.Linq;
using Division.Features.Structures;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.CustomItems;
using Exiled.CustomItems.API.Features;
using Exiled.Loader;
using MEC;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Division.Features.Extensions
{
    public static class Players
    {
        public static void SetSubclass(this Player player, Subclass subclass)
        {
            if (subclass == null)
            {
                player.Scale = Vector3.one;
                return;
            }
            
            // Appearance Options
            if (!string.IsNullOrWhiteSpace(subclass.AppearanceOptions.InfoText))
                player.CustomInfo = string.IsNullOrWhiteSpace(subclass.AppearanceOptions.InfoColor) ? subclass.AppearanceOptions.InfoText : $"<color={subclass.AppearanceOptions.InfoColor}>{subclass.AppearanceOptions.InfoText}</color>";

            Timing.CallDelayed(2.75f, () =>
            {
                // SpawnOptions
                player.Scale = subclass.SpawnOptions.Scale;

                if (subclass.SpawnOptions.Health != -1)
                    player.Health = subclass.SpawnOptions.Health;
                if (subclass.SpawnOptions.MaxHealth != -1)
                    player.MaxHealth = subclass.SpawnOptions.MaxHealth;
                if (subclass.SpawnOptions.Ahp != -1)
                    player.ArtificialHealth = (ushort)subclass.SpawnOptions.Ahp;
                if (subclass.SpawnOptions.MaxAhp != -1)
                    player.MaxArtificialHealth = (ushort)subclass.SpawnOptions.MaxAhp;
                
                if (!subclass.SpawnOptions.SpawnRooms.Contains(RoomType.Unknown))
                {
                    var rooms = Map.Rooms.Where(x => subclass.SpawnOptions.SpawnRooms.Contains(x.Type)).ToList();
                    player.Position = rooms[Random.Range(0, rooms.Count)].Position + Vector3.up;
                }
            });
            
            // Inventory & Ammo
            Timing.CallDelayed(1.25f, () =>
            {
                player.ClearInventory();
                foreach (var slot in subclass.Inventory.ToList())
                {
                    foreach (var item in slot.Keys)
                    {
                        if (Random.Range(0, 101) <= slot[item])
                        {
                            if (player.GiveItem(item))
                                break;
                        }
                    }
                }

                foreach (var ammo in subclass.Ammo)
                    player.Ammo[ammo.Key.GetItemType()] = ammo.Value;
            });
            
            // Messages
            player.Broadcast(subclass.MessageOptions.MessagesDuration, subclass.MessageOptions.SpawnMessage);
        }

        public static bool GiveItem(this Player player, string item)
        {
            if (CustomItem.TryGive(player, item))
                return true;

            if (!Enum.TryParse(item, out ItemType itemType)) 
                return false;
            
            player.AddItem(itemType);
            
            return true;
        }
    }
}
