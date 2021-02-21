using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public delegate void OnGameStateChange(GameStates currentGameState);
    public delegate void OnStartTracking(SlotBase slotBase);

    public class GameController : MonoSingleton<GameController>
    {
        [Header("Number of gears sorted each round")]
        [SerializeField]
        [Range(5, 10)]
        private int gearsPerRound;

        [Header("List of possible gears used in this game")]
        [SerializeField]
        private List<Gear> listGears = new List<Gear>();

        public static event OnGameStateChange onGameStateChange;
        public static event OnStartTracking onStartTracking;

        #region GameState Handlers

        public GameStates currentGameState { get; private set; }

        private void Start()
        {
            ChangeGameState(GameStates.Starting);
        }

        public void ChangeGameState(GameStates newGameState)
        {
            currentGameState = newGameState;

            if (currentGameState == GameStates.Starting)
                StartCoroutine(StartGameRoutine());

            onGameStateChange?.Invoke(currentGameState);
        }

        IEnumerator StartGameRoutine()
        {
            yield return new WaitForSeconds(0.1f);

            ChangeGameState(GameStates.Running);
        }

        #endregion

        public void StartTracking(SlotBase slot)
        {
            if (currentGameState != GameStates.Running) return;

            onStartTracking?.Invoke(slot);
        }

        public List<Gear> GetNewGears()
        {
            //Return a clean list to avoid errors
            if(listGears.Count == 0)
            {
                Debug.Log("There is no gear assigned to this game");

                List<Gear> cleanList = new List<Gear>();

                for(int i = 0; i < gearsPerRound; i++)
                {
                    cleanList.Add(new Gear());
                }

                return cleanList;
            }

            //Complete the actual list to avoid errors
            if(listGears.Count < gearsPerRound)
            {
                Debug.Log("There are no minimum gears assigned");

                for (int i = 0; i < gearsPerRound; i++)
                {
                    listGears.Add(new Gear());
                }

                return Shuffle(listGears);
            }

            //Shuffle the list then pick minimun amount to return
            List<Gear> listShuffled = Shuffle(listGears);
            List<Gear> newList = new List<Gear>();

            for(int i = 0; i < gearsPerRound; i++)
            {
                newList.Add(listShuffled[i]);
            }

            return newList;
        }

        private List<T> Shuffle<T>(List<T> list, int start = 0)
        {
            for (int i = start; i < list.Count; i++)
            {
                T temp = list[i];
                int randomIndex = Random.Range(i, list.Count);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            return list;
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