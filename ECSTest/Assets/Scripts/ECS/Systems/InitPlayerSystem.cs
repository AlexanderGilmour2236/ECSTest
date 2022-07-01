using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class InitPlayerSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private EcsPool<TransformComponent> _transformsPool;
        private EcsPool<LocalPositionComponent> _localPositionsPool;

        public void Init(EcsSystems systems)
        {
            _world = systems.GetWorld();

            _transformsPool = _world.GetPool<TransformComponent>();
            _localPositionsPool = _world.GetPool<LocalPositionComponent>();
            
            int playerEntity = _world.NewEntity();
    
            EcsPool<MovableComponent> movablesPool = _world.GetPool<MovableComponent>();
            EcsPool<InputEventComponent> inputEventsPool = _world.GetPool<InputEventComponent>();
            EcsPool<CharacterAnimationComponent> characterAnimationsPool = _world.GetPool<CharacterAnimationComponent>();
            EcsPool<RadiusComponent> radiusesPool = _world.GetPool<RadiusComponent>();
            
            ref MovableComponent movableComponent = ref movablesPool.Add(playerEntity);
            inputEventsPool.Add(playerEntity);
    
            PlayerInitData playerInitData = PlayerInitData.LoadFromAssets();
            Character playerCharacter = Object.Instantiate(playerInitData.PlayerCharacterPrefab);

            movableComponent.MoveSpeed = playerInitData.DefaultMoveSpeed;

            TransformComponentUtil.InitTransformForEntity(playerEntity, playerCharacter.transform, _transformsPool, _localPositionsPool);

            ref CharacterAnimationComponent characterAnimationComponent = ref characterAnimationsPool.Add(playerEntity);
            characterAnimationComponent.Animator = playerCharacter.Animator;
            characterAnimationComponent.WalkAnimationBoolName = playerCharacter.WalkAnimationBoolName;

            ref RadiusComponent radiusComponent = ref radiusesPool.Add(playerEntity);
            radiusComponent.Radius = playerCharacter.Radius;
        }
    }
}