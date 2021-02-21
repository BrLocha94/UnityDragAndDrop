using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public delegate void OnGearAssign();
    public delegate void OnGearRevome();

    [RequireComponent(typeof(Collider2D))]
    public abstract class SlotBase : MonoBehaviour
    {
        public event OnGearAssign onGearAssign;
        public event OnGearRevome onGearRemove;

        public virtual void AssignGear(Gear newGear) { onGearAssign?.Invoke(); }
        public virtual void RemoveGear() { onGearRemove?.Invoke(); }
        public virtual void TriggerSpecialBehaviour(bool trigger) { }

        public abstract Gear GetGear();
        public abstract void ExcecuteOnMouseDown();
        public abstract bool IsGearActive();

        #region Collision Handlers

        protected virtual void ExecuteOnTriggerEnter2DTrackeble(ITrackeble target) { target.ExecuteOnEnter(this); }
        protected virtual void ExecuteOnTriggerExit2DTrackeble(ITrackeble target) { target.ExcecuteOnExit(this); }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Trackeble"))
            {
                ITrackeble target = collision.GetComponent<ITrackeble>();

                ExecuteOnTriggerEnter2DTrackeble(target);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.Equals("Trackeble"))
            {
                ITrackeble target = collision.GetComponent<ITrackeble>();

                ExecuteOnTriggerExit2DTrackeble(target);
            }
        }

        #endregion
    }
}