using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class TrackebleObject : MonoBehaviour , ITrackeble
    {
        Vector3 initialPosition;

        void Awake()
        {
            initialPosition = transform.position;
        }

        public void ExcecuteOnExit()
        {

        }

        public void ExecuteOnEnter()
        {

        }
    }
}