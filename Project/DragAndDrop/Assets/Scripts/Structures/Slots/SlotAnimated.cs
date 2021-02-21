using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class SlotAnimated : SlotBase
    {
        [SerializeField]
        private GearAnimated gear;

        public override void AssignGear(Gear newGear)
        {
            gear.SetGearValues(newGear.gearType, newGear.gearColor);
            gear.ToogleGear(true);

            base.AssignGear(newGear);
        }

        public override void RemoveGear()
        {
            TriggerSpecialBehaviour(false);
            gear.ToogleGear(false);

            base.RemoveGear();
        }

        public override Gear GetGear() => gear.GetGear();
        public override bool IsGearActive() => gear.isGearActive;

        public override void ExcecuteOnMouseDown()
        {
            if (gear.isGearActive)
                GameController.instance.StartTracking(this);
        }

        private void OnMouseDown()
        {
            ExcecuteOnMouseDown();
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