using System.Collections.Generic;
using UnityEngine;

namespace ECSTest
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Transform _buttonTransform;
        [SerializeField] private string _buttonId;
        [SerializeField] private float _defaultYPosition;
        [SerializeField] private float _pressedYPosition;
        [SerializeField] private float _buttonRadius;

        public string ButtonId
        {
            get { return _buttonId; }
        }
        
        public float DefaultYPosition
        {
            get { return _defaultYPosition; }
        }

        public float PressedYPosition
        {
            get { return _pressedYPosition; }
        }
        
        public Transform ButtonTransform
        {
            get { return _buttonTransform; }
        }
        
        public float ButtonRadius
        {
            get { return _buttonRadius; }
        }
        
    }
}