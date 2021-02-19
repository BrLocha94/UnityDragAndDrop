using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    public abstract class GearBase : MonoBehaviour
    {
        [SerializeField]
        protected GearType gearType = GearType.Null;
        [SerializeField]
        protected Color gearColor = Color.white;

        protected virtual void InitializeOnAwake() { }

        void Awake()
        {
            InitializeOnAwake();    
        }

        public void SetGear(GearType gearType, Color gearColor)
        {
            this.gearType = gearType;
            this.gearColor = gearColor;
        }
    }

    public enum GearType
    {
        Null,
        Pink,
        Cyan,
        Yellow,
        Green,
        Blue
    }
}