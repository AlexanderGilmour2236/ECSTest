using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<InputEventComponent>().Inc<MovableComponent>().Inc<LocalPositionComponent>().End();
            EcsPool<MovableComponent> movablePool = world.GetPool<MovableComponent>();
            EcsPool<InputEventComponent> inputEventsPool = world.GetPool<InputEventComponent>();
            EcsPool<LocalPositionComponent> worldPositionsPool = world.GetPool<LocalPositionComponent>();

            foreach (int entity in filter)
            {
                ref MovableComponent movableComponent = ref movablePool.Get(entity);
                ref LocalPositionComponent localPositionComponent = ref worldPositionsPool.Get(entity);
                
                Vector2 direction = inputEventsPool.Get(entity).MoveDirection;
                Vector3 movementDirection = new Vector3(direction.x, 0, direction.y) * (movableComponent.MoveSpeed * Time.deltaTime);
                
                localPositionComponent.LocalPosition = localPositionComponent.LocalPosition + movementDirection;
                movableComponent.IsMoving = direction.magnitude > 0;
                movableComponent.CurrentMovementDirection = movementDirection;
            }
        }
    }
}