using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class ContainerSlotsAnimated : ContainerSlotsBase
    {
        protected override void ExecuteOnGameStateChange()
        {
            base.ExecuteOnGameStateChange();

            if(currentGameState == GameStates.Starting || currentGameState == GameStates.Restarting)
            {
                for(int i = 0; i < listSlots.Length; i++)
                {
                    if (!activateSlotsOnStart)
                        listSlots[i].RemoveGear();
                }
            }
        }

        protected override void onGearAssign()
        {
            base.onGearAssign();

            if (!CheckSlots()) return;

            for(int i = 0; i < listSlots.Length; i++)
            {
                listSlots[i].TriggerSpecialBehaviour(true);
            }

            GameController.instance.ChangeGameState(GameStates.GameClear);
        }

        protected override void OnGearRemove()
        {
            base.OnGearRemove();

            for (int i = 0; i < listSlots.Length; i++)
            {
                if (listSlots[i].IsGearActive())
                    listSlots[i].TriggerSpecialBehaviour(false);
            }

            if (currentGameState == GameStates.GameClear)
                GameController.instance.ChangeGameState(GameStates.Running);
        }
    }
}