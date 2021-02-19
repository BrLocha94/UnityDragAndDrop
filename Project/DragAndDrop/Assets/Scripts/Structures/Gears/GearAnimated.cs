using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class GearAnimated : GearBase
    {
        SpriteRenderer spriteRenderer;
        Animator animator;

        protected override void InitializeOnAwake()
        {
            base.InitializeOnAwake();

            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        public override void ToogleGear(bool value)
        {
            base.ToogleGear(value);

            if (value)
                spriteRenderer.color = gear.gearColor;
        }
    }
}