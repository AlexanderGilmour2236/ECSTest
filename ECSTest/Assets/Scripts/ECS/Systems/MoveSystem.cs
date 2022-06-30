using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class MoveSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<InputEventComponent>().Inc<MovableComponent>().End();
            EcsPool<MovableComponent> movablePool = world.GetPool<MovableComponent>();
            EcsPool<InputEventComponent> inputEventsPool = world.GetPool<InputEventComponent>();

            foreach (int entity in filter)
            {
                ref MovableComponent movableComponent = ref movablePool.Get(entity);
                Vector2 direction = inputEventsPool.Get(entity).Direction;
                movableComponent.Transform.Translate(new Vector3(direction.x, 0, direction.y) * (movableComponent.MoveSpeed * Time.deltaTime), 
                    Space.World);
                movableComponent.IsMoving = direction.magnitude > 0;
                movableComponent.CurrentMovementDirection = direction;
            }
        }
    }
}