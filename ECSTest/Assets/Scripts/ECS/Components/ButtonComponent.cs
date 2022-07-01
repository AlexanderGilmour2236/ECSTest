using System.Collections.Generic;
using UnityEngine;

namespace ECSTest
{
    public struct ButtonComponent
    {
        public string ButtonId;
        public bool IsPressed;
        public float ButtonRadius;
        public float DefaultYPosition;
        public float PressedYPosition;
    }
}