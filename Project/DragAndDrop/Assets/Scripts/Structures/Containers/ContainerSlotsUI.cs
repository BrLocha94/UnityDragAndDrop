using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class ContainerSlotsUI : ContainerSlotsBase
    {
        protected override void ExecuteOnGameStateChange()
        {
            base.ExecuteOnGameStateChange();

            if (currentGameState == GameStates.Starting || currentGameState == GameStates.Restarting)
            {
                List<Gear> listGears = GameController.instance.GetNewGears();

                if (listGears.Count != listSlots.Length)
                {
                    Debug.Log("The slots list does not have minimum capacity of " + listGears.Count);
                    return;
                }

                for (int i = 0; i < listSlots.Length; i++)
                {
                    if (activateSlotsOnStart)
                    {
                        listSlots[i].AssignGear(listGears[i]);
                    }
                }
            }
        }


    }
}