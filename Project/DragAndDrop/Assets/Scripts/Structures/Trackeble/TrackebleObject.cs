using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class TrackebleObject : MonoBehaviour , ITrackeble
    {
        SlotBase slotOriginal = null;
        SlotBase slotCurrent = null;

        bool isTracking = false;

        SpriteRenderer spriteRenderer;
        Vector3 initialPosition;
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
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
            spriteRenderer.color = slot.GetGear().gearColor;

            slotOriginal = slot;
            slotOriginal.RemoveGear();
            slotCurrent = null;

            isTracking = true;
        }

        void FinishTracking()
        {
            if (slotCurrent)
            {
                if (slotCurrent.IsGearActive())
                    Debug.Log("Current slot already has a gear, cant move to there");

                else
                {
                    slotCurrent.AssignGear(slotOriginal.GetGear());
                    slotOriginal.RemoveGear();
                }
            }
            else
                slotOriginal.AssignGear(slotOriginal.GetGear());

            isTracking = false;
            transform.position = initialPosition;
        }
    }
}