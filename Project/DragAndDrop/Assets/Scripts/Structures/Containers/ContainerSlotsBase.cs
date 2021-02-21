using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public abstract class ContainerSlotsBase : GameStateReceiver
    {
        [Header("Toogle this if the gear is active on start in the slots")]
        [SerializeField]
        protected bool activateSlotsOnStart = false;

        [Space]

        [Header("Slots assigned to this container")]
        [SerializeField]
        protected SlotBase[] listSlots;

        protected override void ExecuteOnEnable()
        {
            base.ExecuteOnEnable();

            for(int i = 0; i < listSlots.Length; i++)
            {
                listSlots[i].onGearAssign += onGearAssign;
                listSlots[i].onGearRemove += OnGearRemove;
            }
        }

        protected override void ExecuteOnDisable()
        {
            base.ExecuteOnDisable();

            for (int i = 0; i < listSlots.Length; i++)
            {
                listSlots[i].onGearRemove -= onGearAssign;
                listSlots[i].onGearRemove -= OnGearRemove;
            }
        }

        protected virtual void onGearAssign() { }
        protected virtual void OnGearRemove() { }

        protected bool CheckSlots()
        {
            for(int i = 0; i < listSlots.Length; i++)
            {
                if (!listSlots[i].IsGearActive()) return false;
            }

            return true;
        }
    }
}