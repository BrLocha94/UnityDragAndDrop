﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class SlotUi : SlotBase
    {
        [SerializeField]
        private GearUi gear;

        public override void AssignGear(GearSerialized newGear)
        {
            gear.SetGearValues(newGear.gearType, newGear.gearColor);
            gear.ToogleGear(true);

            base.AssignGear(newGear);
        }

        public override void RemoveGear()
        {
            gear.ToogleGear(false);

            base.RemoveGear();
        }

        public override GearSerialized GetGear() => gear.GetGear();
        public override bool IsGearActive() => gear.isGearActive;

        public override void ExcecuteOnMouseDown()
        {
            if(gear.isGearActive)
                GameController.instance.StartTracking(this);
        }

        protected override void ExecuteOnTriggerEnter2DTrackeble(ITrackeble target)
        {
            if (gear == null)
            {
                Debug.Log("There is no gear assigned to this slot");
                return;
            }

            base.ExecuteOnTriggerEnter2DTrackeble(target);
        }

        protected override void ExecuteOnTriggerExit2DTrackeble(ITrackeble target)
        {
            if (gear == null)
            {
                Debug.Log("There is no gear assigned to this slot");
                return;
            }

            base.ExecuteOnTriggerExit2DTrackeble(target);
        }
    }
}