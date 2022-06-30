using Leopotam.EcsLite;
using Level;
using UnityEngine;

namespace ECSTest
{
    public class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        
        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();
            InitPlayerEntity();
            InitLevelEntities();
        }
        
        private void InitPlayerEntity()
        {
            int playerEntity = _world.NewEntity();
    
            EcsPool<MovableComponent> movablesPool = _world.GetPool<MovableComponent>();
            EcsPool<InputEventComponent> inputEventsPool = _world.GetPool<InputEventComponent>();
            EcsPool<CharacterAnimationComponent> characterAnimationsPool = _world.GetPool<CharacterAnimationComponent>();
            
            ref MovableComponent movableComponent = ref movablesPool.Add(playerEntity);
            inputEventsPool.Add(playerEntity);
    
            PlayerInitData playerInitData = PlayerInitData.LoadFromAssets();
            Character playerCharacter = Object.Instantiate<Character>(playerInitData.PlayerCharacterPrefab);
            
            movableComponent.Transform = playerCharacter.transform;
            movableComponent.MoveSpeed = playerInitData.DefaultMoveSpeed;

            ref CharacterAnimationComponent characterAnimationComponent = ref characterAnimationsPool.Add(playerEntity);
            characterAnimationComponent.Animator = playerCharacter.Animator;
            characterAnimationComponent.WalkAnimationBoolName = playerCharacter.WalkAnimationBoolName;
            
            
        }
        
        private void InitLevelEntities()
        {
            LevelInitData levelInitData = LevelInitData.LoadFromResources();
            Level.Level level = Object.Instantiate(levelInitData.LevelPrefab, Vector3.zero, Quaternion.identity);
            EcsPool<DoorComponent> doorComponentsPool = _world.GetPool<DoorComponent>();
            EcsPool<HoldButtonComponent> buttonComponentsPool = _world.GetPool<HoldButtonComponent>();
            
            foreach (Door levelDoor in level.Doors)
            {
                int doorEntity = _world.NewEntity();
                ref DoorComponent doorComponent = ref doorComponentsPool.Add(doorEntity);
                
                doorComponent.DoorId = levelDoor.DoorId;
                doorComponent.DoorTransform = levelDoor.transform;
                doorComponent.OpenCloseSpeed = levelDoor.OpenCloseSpeed;
            }
            
            foreach (LevelButton levelButton in level.LevelButtons)
            {
                int levelButtonEntity = _world.NewEntity();
                ref HoldButtonComponent holdButtonComponent = ref buttonComponentsPool.Add(levelButtonEntity);
                
                holdButtonComponent.ButtonId = levelButton.ButtonId;
                holdButtonComponent.ButtonTransform = levelButton.transform;
            }
        }
    }

}
