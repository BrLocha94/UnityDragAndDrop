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

        public override void ToogleGear(bool value)
        {
            base.ToogleGear(value);

            if (value)
                image.color = gear.gearColor;
        }
    }
}