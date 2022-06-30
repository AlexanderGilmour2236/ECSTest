using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class GameLoader : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _ecsSystems;
        
        void Start()
        {
            _world = new EcsWorld();
            _ecsSystems = new EcsSystems(_world);
            _ecsSystems.Add(new GameInitSystem());
            _ecsSystems.Add(new KeyboardInputSystem());
            _ecsSystems.Add(new PointToClickInputSystem());
            _ecsSystems.Add(new MoveSystem());
            _ecsSystems.Add(new CharacterAnimationSystem());
            _ecsSystems.Add(new RotateMovablesSystem());
            
            _ecsSystems.Add(new OpenDoorsSystem());
            _ecsSystems.Add(new ButtonsSystem());
            
            _ecsSystems.Init();
        }
    
        void Update()
        {
            _ecsSystems.Run();   
        }
    
        private void OnDestroy()
        {
            _world.Destroy();
            _ecsSystems.Destroy();
        }
    }
}
