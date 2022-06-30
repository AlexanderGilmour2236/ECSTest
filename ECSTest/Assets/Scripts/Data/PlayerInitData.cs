using UnityEngine;

namespace ECSTest
{
    [CreateAssetMenu]
    public class PlayerInitData : ScriptableObject
    {
        public Character PlayerCharacterPrefab;
        public float DefaultMoveSpeed;

        public static PlayerInitData LoadFromAssets()
        {
            return Resources.Load<PlayerInitData>(ResourcesPathsData.PlayerInitDataPath);
        }
    }
}