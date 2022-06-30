using UnityEngine;

namespace Level
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private string _doorId;
        [SerializeField] private float _openCloseSpeed;
        [SerializeField] private float _openedYPosition;
        [SerializeField] private float _closedYPosition;
        [SerializeField] private Transform _doorTransform;

        public Transform DoorTransform
        {
            get { return _doorTransform; }
        }

        public float OpenedYPosition
        {
            get { return _openedYPosition; }
        }

        public float ClosedYPosition
        {
            get { return _closedYPosition; }
        }

        public string DoorId
        {
            get { return _doorId; }
        }

        public float OpenCloseSpeed
        {
            get { return _openCloseSpeed; }
        }
    }
}