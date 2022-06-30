using UnityEngine;

namespace ECSTest
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Door[] _doors;
        [SerializeField] private LevelButton[] _levelButtons;
        
        public Door[] Doors
        {
            get { return _doors; }
        }

        public LevelButton[] LevelButtons
        {
            get { return _levelButtons; }
        }
    }
}