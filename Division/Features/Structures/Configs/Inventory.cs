using System.Collections.Generic;

namespace Division.Features.Structures.Configs
{
    public class Inventory
    {
        public Dictionary<string, float> Slot1 { get; set; } = new Dictionary<string, float>()
        {
            {
                "Coin", 100
            }
        };
        public Dictionary<string, float> Slot2 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot3 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot4 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot5 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot6 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot7 { get; set; } = new Dictionary<string, float>();
        public Dictionary<string, float> Slot8 { get; set; } = new Dictionary<string, float>();

        public List<Dictionary<string, float>> ToList() => new List<Dictionary<string, float>>
        {
            Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8
        };
    }
}