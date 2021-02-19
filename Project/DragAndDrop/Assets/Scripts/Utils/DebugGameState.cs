using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    [RequireComponent(typeof(Text))]
    public class DebugGameState : GameStateReceiver
    {
        Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        void Update()
        {
            text.text = currentGameState.ToString();
        }
    }
}