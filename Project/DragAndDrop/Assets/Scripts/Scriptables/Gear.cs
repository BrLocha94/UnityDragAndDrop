using System;
using UnityEngine;

namespace Project.Main
{
    [CreateAssetMenu(fileName = "Gear", menuName = "GameStructures/Gear")]
    public class Gear : ScriptableObject
    {
        public GearType gearType = GearType.Null;
        public Color gearColor = Color.white;
    }

    public enum GearType
    {
        Null,
        Pink,
        Cyan,
        Yellow,
        Green,
        Blue,
        Black,
        Orange,
        Purple,
        Red,
        White
    }
}