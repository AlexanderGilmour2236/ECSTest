using Leopotam.EcsLite;
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
            Level level = Object.Instantiate(levelInitData.LevelPrefab, Vector3.zero, Quaternion.identity);
            InitDoors(level);
            InitButtons(level);
        }

        private void InitButtons(Level level)
        {
            EcsPool<ButtonComponent> buttonComponentsPool = _world.GetPool<ButtonComponent>();

            foreach (LevelButton levelButton in level.LevelButtons)
            {
                int levelButtonEntity = _world.NewEntity();
                ref ButtonComponent buttonComponent = ref buttonComponentsPool.Add(levelButtonEntity);
                
                buttonComponent.ButtonIds = levelButton.ButtonIds;
                buttonComponent.ButtonTransform = levelButton.ButtonTransform;
                buttonComponent.DefaultYPosition = levelButton.DefaultYPosition;
                buttonComponent.PressedYPosition = levelButton.PressedYPosition;
                buttonComponent.ButtonRadius = levelButton.ButtonRadius;
                buttonComponent.ButtonActionType = levelButton.ButtonActionType;
            }   
        }

        private void InitDoors(Level level)
        {
            EcsPool<DoorComponent> doorComponentsPool = _world.GetPool<DoorComponent>();

            foreach (Door levelDoor in level.Doors)
            {
                int doorEntity = _world.NewEntity();
                ref DoorComponent doorComponent = ref doorComponentsPool.Add(doorEntity);
                
                doorComponent.DoorId = levelDoor.DoorId;
                doorComponent.DoorTransform = levelDoor.DoorTransform;
                doorComponent.OpenCloseSpeed = levelDoor.OpenCloseSpeed;
                
                doorComponent.OpenDoorYPosition = levelDoor.OpenedYPosition;
                doorComponent.ClosedDoorYPosition = levelDoor.ClosedYPosition;
            }
        }
    }

}
