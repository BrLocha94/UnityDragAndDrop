using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    public class Baloon : MonoBehaviour
    {
        [Header("Text reference to write")]
        [SerializeField]
        private Text targetText;

        [Header("Strings to be changed on baloon")]
        [SerializeField]
        private string textRunning;
        [SerializeField]
        private string textGameClear;

        public void UpdateText(GameStates gameState)
        {
            if (gameState == GameStates.GameClear)
                targetText.text = textGameClear;

            else
                targetText.text = textRunning;
        }
    }
}