using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class SlotBase : MonoBehaviour
    {

        private Collider2D colliderMain;
        void Awake()
        {
            colliderMain = GetComponent<Collider2D>();
        }

        #region Collision Handlers

        protected virtual void ExecuteOnTriggerEnter2DTrackeble() { }
        protected virtual void ExecuteOnTriggerExit2DTrackeble() { }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Trackeble"))
            {
                ExecuteOnTriggerEnter2DTrackeble();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.Equals("Trackeble"))
            {
                ExecuteOnTriggerExit2DTrackeble();
            }
        }

        #endregion

        #region Click Handlers

        protected virtual void InitializeOnMouseDown() { }
        protected virtual void InitializeOnMouseUp() { }

        void OnMouseDown()
        {
            InitializeOnMouseDown();
        }

        void OnMouseUp()
        {
            InitializeOnMouseUp();
        }

        #endregion
    }
}