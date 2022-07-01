using UnityEngine;

namespace ECSTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _walkAnimationBoolName;
        [SerializeField] private float _radius;

        public Animator Animator
        {
            get { return _animator; }
        }
        
        public string WalkAnimationBoolName
        {
            get { return _walkAnimationBoolName; }
        }
        
        public float Radius
        {
            get { return _radius; }
        }
    }
}