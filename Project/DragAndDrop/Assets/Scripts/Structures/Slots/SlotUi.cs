using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class SlotUi : SlotBase
    {
        [SerializeField]
        private GearUi gear;

        public override void AssignGear(Gear newGear)
        {
            gear.SetGearValues(newGear.gearType, newGear.gearColor);

            gear.ToogleGear(true);
        }

        public override void RemoveGear()
        {
            gear.ToogleGear(false);
        }

        public override Gear GetGear() => gear.GetGear();

        public override void ExcecuteOnMouseDown()
        {
            GameController.instance.StartTracking(this);
        }
    }
}