using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    public abstract class GearBase : MonoBehaviour
    {
        [SerializeField]
        protected Gear gear;

        protected virtual void InitializeOnAwake() { }

        void Awake()
        {
            gear = new Gear();

            InitializeOnAwake();    
        }

        public void SetGearValues(GearType gearType, Color gearColor)
        {
            gear.gearType = gearType;
            gear.gearColor = gearColor;
        }

        public Gear GetGear()
        {
            return gear;
        }

        public virtual void ToogleGear(bool value)
        {
            gameObject.SetActive(value);
        }
    }

    [Serializable]
    public class Gear
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
        Blue
    }
}