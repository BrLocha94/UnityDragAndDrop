using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public delegate void OnGameStateChange(GameStates currentGameState);
    public delegate void OnStartTracking(SlotBase slotBase);

    public class GameController : MonoSingleton<GameController>
    {
        public static event OnGameStateChange onGameStateChange;
        public static event OnStartTracking onStartTracking;

        #region GameState Handlers

        public GameStates currentGameState { get; private set; }

        protected override void InitializeOnAwake()
        {
            base.InitializeOnAwake();

            ChangeGameState(GameStates.Starting);
        }

        public void ChangeGameState(GameStates newGameState)
        {
            currentGameState = newGameState;

            if (currentGameState == GameStates.Starting)
                StartCoroutine(StartGameRoutine());

            onGameStateChange?.Invoke(currentGameState);
        }

        #endregion

        public void StartTracking(SlotBase slot)
        {
            if (currentGameState != GameStates.Running) return;

            onStartTracking?.Invoke(slot);
        }

        IEnumerator StartGameRoutine()
        {
            yield return new WaitForSeconds(0.1f);

            ChangeGameState(GameStates.Running);
        }
    }

    public enum GameStates
    {
        Null,
        Starting,
        Running,
        Paused,
        GameClear,
        Restarting
    }
}