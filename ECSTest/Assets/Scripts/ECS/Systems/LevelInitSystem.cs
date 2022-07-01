using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class LevelInitSystem : IEcsInitSystem
    {
        private EcsWorld _world = null;
        private EcsPool<TransformComponent> _transformsPool;
        private EcsPool<LocalPositionComponent> _localPositionsPool;
        
        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();

            _transformsPool = _world.GetPool<TransformComponent>();
            _localPositionsPool = _world.GetPool<LocalPositionComponent>();
            
            InitLevelEntities();
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
            EcsPool<ButtonAnimationComponent> buttonAnimationsPool = _world.GetPool<ButtonAnimationComponent>();
            EcsPool<RadiusComponent> radiusesPool = _world.GetPool<RadiusComponent>();

            foreach (LevelButton levelButton in level.LevelButtons)
            {
                int levelButtonEntity = _world.NewEntity();
                ref ButtonComponent buttonComponent = ref buttonComponentsPool.Add(levelButtonEntity);
                ref LocalPositionComponent buttonLocalPositionComponent = ref _localPositionsPool.Add(levelButtonEntity);
                ref TransformComponent transformComponent = ref _transformsPool.Add(levelButtonEntity);
                ref ButtonAnimationComponent buttonAnimationComponent = ref buttonAnimationsPool.Add(levelButtonEntity);
                ref RadiusComponent radiusComponent = ref radiusesPool.Add(levelButtonEntity);
                
                buttonComponent.ButtonId = levelButton.ButtonId;
                radiusComponent.Radius = levelButton.ButtonRadius;
                
                buttonAnimationComponent.ButtonTransform = levelButton.ButtonTransform;
                buttonAnimationComponent.DefaultYPosition = levelButton.DefaultYPosition;
                buttonAnimationComponent.PressedYPosition = levelButton.PressedYPosition;
                
                transformComponent.Transform = levelButton.transform;
                
                buttonLocalPositionComponent.LocalPosition = transformComponent.Transform.localPosition;
                buttonLocalPositionComponent.LocalRotation = transformComponent.Transform.localRotation;
            }   
        }

        private void InitDoors(Level level)
        {
            EcsPool<DoorComponent> doorComponentsPool = _world.GetPool<DoorComponent>();

            foreach (Door levelDoor in level.Doors)
            {
                int doorEntity = _world.NewEntity();
                ref DoorComponent doorComponent = ref doorComponentsPool.Add(doorEntity);
                ref LocalPositionComponent localPositionComponent = ref _localPositionsPool.Add(doorEntity);
                ref TransformComponent transformComponent = ref _transformsPool.Add(doorEntity);
                
                doorComponent.DoorId = levelDoor.DoorId;
                doorComponent.OpenCloseSpeed = levelDoor.OpenCloseSpeed;
                
                doorComponent.OpenDoorYPosition = levelDoor.OpenedYPosition;
                doorComponent.ClosedDoorYPosition = levelDoor.ClosedYPosition;
                
                localPositionComponent.LocalPosition = levelDoor.DoorTransform.localPosition;
                
                transformComponent.Transform = levelDoor.DoorTransform;
            }
        }
    }

}
