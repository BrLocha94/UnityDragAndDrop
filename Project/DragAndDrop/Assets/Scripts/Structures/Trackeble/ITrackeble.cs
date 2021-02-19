using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Main
{
    public interface ITrackeble
    {
        void ExecuteOnEnter(SlotBase slot);
        void ExcecuteOnExit(SlotBase slot);
        void StartTracking(SlotBase slot);
    }
}