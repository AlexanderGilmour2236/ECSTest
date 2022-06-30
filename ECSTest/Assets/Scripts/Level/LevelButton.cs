using System.Collections.Generic;
using UnityEngine;

namespace ECSTest
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Transform _buttonTransform;
        [SerializeField] private List<string> _buttonIds;
        [SerializeField] private float _defaultYPosition;
        [SerializeField] private float _pressedYPosition;
        [SerializeField] private float _buttonRadius;
        [SerializeField] private ButtonActionType _buttonActionType;

        public List<string> ButtonIds
        {
            get { return _buttonIds; }
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
        
        public ButtonActionType ButtonActionType
        {
            get { return _buttonActionType; }
        }
    }
}