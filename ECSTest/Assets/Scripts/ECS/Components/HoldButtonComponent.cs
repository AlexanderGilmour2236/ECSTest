using UnityEngine;

namespace ECSTest
{
    public struct HoldButtonComponent
    {
        public Transform ButtonTransform;
        public string ButtonId;
        public bool IsPressed;
    }
}