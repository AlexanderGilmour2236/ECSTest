using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class ButtonsSystem : IEcsRunSystem
    {
        private const float DISTANCE_TO_PRESS = 2.0f;

        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter buttons = world.Filter<HoldButtonComponent>().End();
            EcsFilter movables = world.Filter<MovableComponent>().End();
            EcsPool<HoldButtonComponent> buttonsPool = world.GetPool<HoldButtonComponent>();
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();

            foreach (int buttonEntity in buttons)
            {
                foreach (int movableEntity in movables)
                {
                    ref HoldButtonComponent holdButtonComponent = ref buttonsPool.Get(buttonEntity);
                    float distance = Vector3.Distance(holdButtonComponent.ButtonTransform.position,
                        movablesPool.Get(movableEntity).Transform.position);

                    holdButtonComponent.IsPressed = distance <= DISTANCE_TO_PRESS;
                    if (holdButtonComponent.IsPressed)
                    {
                        break;
                    }
                }
            }
        }
    }
} 