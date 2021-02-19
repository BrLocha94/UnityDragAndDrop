using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class TrackebleObject : MonoBehaviour , ITrackeble
    {
        SlotBase slotOriginal = null;
        SlotBase slotCurrent = null;

        bool isTracking = false;

        Vector3 initialPosition;
        void Awake()
        {
            initialPosition = transform.position;
        }

        void OnEnable()
        {
            GameController.onStartTracking += StartTracking;    
        }

        void OnDisable()
        {
            GameController.onStartTracking -= StartTracking;
        }

        void Update()
        {
            if (!isTracking) return;

            if (Input.GetMouseButton(0))
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
                transform.position = Camera.main.ScreenToWorldPoint(position);
                transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            }
            else
                FinishTracking();
        }

        public void ExecuteOnEnter(SlotBase slot)
        {
            if (slot == slotOriginal) return;

            if (slot == slotCurrent) return;

            slotCurrent = slot;
        }

        public void ExcecuteOnExit(SlotBase slot)
        {
            if (slot == slotOriginal) return;

            if (slot != slotCurrent) return;

            slotCurrent = null;
        }

        public void StartTracking(SlotBase slot)
        {
            slotOriginal = slot;
            slotCurrent = null;

            isTracking = true;
        }

        void FinishTracking()
        {
            if(slotOriginal && slotCurrent)
            {
                slotCurrent.AssignGear(slotOriginal.GetGear());
                slotOriginal.RemoveGear();
            }

            isTracking = false;
            transform.position = initialPosition;
        }
    }
}