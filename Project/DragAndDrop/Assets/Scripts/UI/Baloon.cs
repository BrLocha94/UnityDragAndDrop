using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    public class Baloon : MonoBehaviour
    {
        [Header("Background image to toogle on and off")]
        [SerializeField]
        private Image imageBorder;
        [SerializeField]
        private Color colorOn = Color.yellow;
        [SerializeField]
        private Color colorOff = new Color(1f, 1f, 1f, 0f);

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
            {
                imageBorder.color = colorOn;
                targetText.text = textGameClear;
            }
            else
            {
                imageBorder.color = colorOff;
                targetText.text = textRunning;
            }
        }
    }
}