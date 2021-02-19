using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Main
{
    [RequireComponent(typeof(Image))]
    public class GearUi : GearBase
    {
        Image image;

        protected override void InitializeOnAwake()
        {
            base.InitializeOnAwake();

            image = GetComponent<Image>();
        }
    }
}