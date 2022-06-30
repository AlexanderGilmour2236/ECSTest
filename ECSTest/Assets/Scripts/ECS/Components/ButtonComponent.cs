using System.Collections.Generic;
using UnityEngine;

namespace ECSTest
{
    public struct ButtonComponent
    {
        public Transform ButtonTransform;
        public List<string> ButtonIds;
        public bool IsPressed;
        public float ButtonRadius;
        public float DefaultYPosition;
        public float PressedYPosition;
        public ButtonActionType ButtonActionType;
    }
}