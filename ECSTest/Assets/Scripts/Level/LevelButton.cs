using UnityEngine;

namespace Level
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private string _buttonId;

        public string ButtonId
        {
            get { return _buttonId; }
        }
    }
}