using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    public abstract class GearBase : MonoBehaviour
    {
        public bool isGearActive { get; private set; }

        [SerializeField]
        protected GearSerialized gear;

        protected virtual void InitializeOnAwake() { }

        void Awake()
        {
            isGearActive = true;

            InitializeOnAwake();    
        }

        public void SetGearValues(GearType gearType, Color gearColor)
        {
            gear.gearType = gearType;
            gear.gearColor = gearColor;
        }

        public GearSerialized GetGear()
        {
            return gear;
        }

        public virtual void ToogleGear(bool value)
        {
            isGearActive = value;
            gameObject.SetActive(value);
        }
    }
}