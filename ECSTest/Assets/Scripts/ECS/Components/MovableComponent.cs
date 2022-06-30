using UnityEngine;

namespace ECSTest
{
    public struct MovableComponent
    {
        public Transform Transform;
        public float MoveSpeed;
        public bool IsMoving;
        public Vector3 CurrentMovementDirection;
    }
}

