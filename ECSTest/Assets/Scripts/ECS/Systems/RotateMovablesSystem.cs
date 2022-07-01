using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class RotateMovablesSystem : IEcsRunSystem
    {
        private const float ROTATION_LERP_SPEED = 0.3f;

        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter movablesFilter = world.Filter<MovableComponent>().Inc<LocalPositionComponent>().End();
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();
            EcsPool<LocalPositionComponent> worldPositionsPool = world.GetPool<LocalPositionComponent>();
            
            foreach (int movableEntity in movablesFilter)
            {
                ref MovableComponent movableComponent = ref movablesPool.Get(movableEntity);
                ref LocalPositionComponent localPositionComponent = ref worldPositionsPool.Get(movableEntity);
                if (movableComponent.IsMoving)
                {
                    localPositionComponent.LocalRotation = Quaternion.Lerp(localPositionComponent.LocalRotation, 
                        Quaternion.LookRotation(movableComponent.CurrentMovementDirection), ROTATION_LERP_SPEED);
                }
            }
        }
    }
}