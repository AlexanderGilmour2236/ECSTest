using UnityEngine;

namespace ECSTest
{
    public struct DoorComponent
    {
        public Transform DoorTransform;
        public string DoorId;
        public float OpenCloseSpeed;
        public float OpenDoorYPosition;
        public float ClosedDoorYPosition;
    }
}