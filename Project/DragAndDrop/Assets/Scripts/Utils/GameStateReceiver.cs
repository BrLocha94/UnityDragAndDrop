using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public class GameStateReceiver : MonoBehaviour
    {
        protected GameStates currentGameState;

        protected virtual void ExecuteOnGameStateChange() { }
        protected virtual void ExecuteOnStart() { }
        protected virtual void ExecuteOnEnable() { }
        protected virtual void ExecuteOnDisable() { }

        private void OnGameStateChange(GameStates newGameState)
        {
            currentGameState = newGameState;

            ExecuteOnGameStateChange();
        }

        void Start()
        {
            OnGameStateChange(GameController.instance.currentGameState);

            ExecuteOnStart();
        }

        void OnEnable()
        {
            GameController.onGameStateChange += OnGameStateChange;

            ExecuteOnEnable();
        }

        void OnDisable()
        {
            GameController.onGameStateChange -= OnGameStateChange;

            ExecuteOnDisable();
        }
    }
}