using UnityEngine;

namespace Project.Main
{
    [System.Serializable]
    public class GearSerialized
    {
        public GearType gearType;
        public Color gearColor;

        public GearSerialized()
        {
            gearType = GearType.Null;
            gearColor = Color.white;
        }

        public GearSerialized(Gear gear)
        {
            gearType = gear.gearType;
            gearColor = gear.gearColor;
        }
    }
}