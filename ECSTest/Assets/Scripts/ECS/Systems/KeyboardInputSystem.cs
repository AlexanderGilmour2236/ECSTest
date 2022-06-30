using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class KeyboardInputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.A))
            {
                direction.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.x += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.y -= 1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction.y += 1;
            }

            EcsWorld world = systems.GetWorld();
            EcsFilter filter = world.Filter<InputEventComponent>().End();
            EcsPool<InputEventComponent> inputEventsPool = world.GetPool<InputEventComponent>();
            
            foreach (int entity in filter)
            {
                inputEventsPool.Get(entity).Direction = direction;
            }
        }
    }
}