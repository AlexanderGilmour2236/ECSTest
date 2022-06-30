using UnityEngine;

namespace ECSTest
{
    [CreateAssetMenu]
    public class LevelInitData : ScriptableObject
    {
        public Level.Level LevelPrefab;

        public static LevelInitData LoadFromResources()
        {
            return Resources.Load<LevelInitData>(ResourcesPathsData.LevelInitDataPath);
        }
    }
}