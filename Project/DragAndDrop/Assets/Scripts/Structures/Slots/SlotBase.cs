using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class SlotBase : MonoBehaviour
    {
        public abstract void AssignGear(Gear newGear);
        public abstract void RemoveGear();
        public abstract Gear GetGear();

        #region Collision Handlers

        protected virtual void ExecuteOnTriggerEnter2DTrackeble(ITrackeble target) { target.ExecuteOnEnter(this); }
        protected virtual void ExecuteOnTriggerExit2DTrackeble(ITrackeble target) { target.ExcecuteOnExit(this); }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Collision enter");

            if (collision.tag.Equals("Trackeble"))
            {
                ITrackeble target = collision.GetComponent<ITrackeble>();

                ExecuteOnTriggerEnter2DTrackeble(target);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Collision exit");

            if (collision.tag.Equals("Trackeble"))
            {
                ITrackeble target = collision.GetComponent<ITrackeble>();

                ExecuteOnTriggerExit2DTrackeble(target);
            }
        }

        #endregion

        public abstract void ExcecuteOnMouseDown();

    }
}