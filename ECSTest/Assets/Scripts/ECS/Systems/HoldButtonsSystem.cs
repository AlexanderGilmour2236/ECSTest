using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace ECSTest
{
    public class HoldButtonsSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter buttons = world.Filter<ButtonComponent>().Inc<LocalPositionComponent>().End();
            EcsFilter movables = world.Filter<MovableComponent>().Inc<LocalPositionComponent>().End();
            
            EcsPool<ButtonComponent> buttonsPool = world.GetPool<ButtonComponent>();
            EcsPool<LocalPositionComponent> localPositionsPool = world.GetPool<LocalPositionComponent>();

            foreach (int buttonEntity in buttons)
            {
                ref ButtonComponent buttonComponent = ref buttonsPool.Get(buttonEntity);
                ref LocalPositionComponent buttonLocalPositionComponent = ref localPositionsPool.Get(buttonEntity);
                
                foreach (int movableEntity in movables)
                {
                    ref LocalPositionComponent movableLocalPositionComponent =
                        ref localPositionsPool.Get(movableEntity);
                    
                    Vector3 buttonPosition = buttonLocalPositionComponent.LocalPosition;
                    Vector3 movablePosition = movableLocalPositionComponent.LocalPosition;
                    buttonPosition.y = 0;
                    movablePosition.y = 0;
                    
                    float distance = Vector3.Distance(buttonPosition,
                        movablePosition);

                    buttonComponent.IsPressed = distance <= buttonComponent.ButtonRadius;
                    if (buttonComponent.IsPressed)
                    {
                        break;
                    }
                }
            }
        }
    }
} 