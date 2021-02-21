using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class GearAnimated : GearBase
    {
        [Header("Animation time base in seconds")]
        [SerializeField]
        [Range(0.1f, 1f)]
        private float animationTime;

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

        public virtual void TriggerSpecialBehaviour(bool trigger)
        {
            if (trigger == true)
                animator.speed = animationTime;
            else
                animator.speed = 0f;
        }
    }
}