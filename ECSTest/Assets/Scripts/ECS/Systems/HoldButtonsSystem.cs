using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class HoldButtonsSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter buttons = world.Filter<ButtonComponent>().End();
            EcsFilter movables = world.Filter<MovableComponent>().End();
            EcsPool<ButtonComponent> buttonsPool = world.GetPool<ButtonComponent>();
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();

            foreach (int buttonEntity in buttons)
            {
                ref ButtonComponent buttonComponent = ref buttonsPool.Get(buttonEntity);
                
                foreach (int movableEntity in movables)
                {
                    Vector3 buttonTransformPosition = buttonComponent.ButtonTransform.position;
                    Vector3 movableTransformPosition = movablesPool.Get(movableEntity).Transform.position;
                    buttonTransformPosition.y = 0;
                    movableTransformPosition.y = 0;
                    
                    float distance = Vector3.Distance(buttonTransformPosition,
                        movableTransformPosition);

                    buttonComponent.IsPressed = distance <= buttonComponent.ButtonRadius;
                    if (buttonComponent.IsPressed)
                    {
                        break;
                    }
                }
                
                Vector3 buttonTransformLocalPosition = buttonComponent.ButtonTransform.localPosition;
                buttonTransformLocalPosition.y = buttonComponent.IsPressed ? buttonComponent.PressedYPosition : buttonComponent.DefaultYPosition;
                buttonComponent.ButtonTransform.localPosition = buttonTransformLocalPosition;
            }
        }
    }
} 