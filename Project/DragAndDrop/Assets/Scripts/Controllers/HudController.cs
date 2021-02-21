using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class HudController : GameStateReceiver
    {
        [SerializeField]
        private Baloon baloon;

        protected override void ExecuteOnGameStateChange()
        {
            base.ExecuteOnGameStateChange();

            if (baloon != null)
                baloon.UpdateText(currentGameState);

            else
                Debug.Log("There is no ballon assigned on this script");
        }

        public void OnResetClicked()
        {
            GameController.instance.ChangeGameState(GameStates.Restarting);
        }
    }
}