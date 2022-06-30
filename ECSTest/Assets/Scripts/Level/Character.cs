using UnityEngine;

namespace ECSTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _walkAnimationBoolName;

        public Animator Animator
        {
            get { return _animator; }
        }
        
        public string WalkAnimationBoolName
        {
            get { return _walkAnimationBoolName; }
        }
    }
}