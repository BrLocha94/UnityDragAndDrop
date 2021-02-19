using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class SlotAnimated : SlotBase
    {
        [SerializeField]
        private GearAnimated gear;

        protected override void ExecuteOnTriggerEnter2DTrackeble()
        {
            base.ExecuteOnTriggerEnter2DTrackeble();
        }

        protected override void ExecuteOnTriggerExit2DTrackeble()
        {
            base.ExecuteOnTriggerExit2DTrackeble();
        }
    }
}