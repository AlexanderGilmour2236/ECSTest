using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class ButtonAnimationSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter buttonsFilter = world.Filter<ButtonComponent>().Inc<ButtonAnimationComponent>().End();
            EcsPool<ButtonComponent> buttonsPool = world.GetPool<ButtonComponent>();
            EcsPool<ButtonAnimationComponent> buttonsAnimationPool = world.GetPool<ButtonAnimationComponent>();
            
            foreach (int buttonEntity in buttonsFilter)
            {
                ButtonComponent buttonComponent = buttonsPool.Get(buttonEntity);
                ref ButtonAnimationComponent buttonAnimationComponent = ref buttonsAnimationPool.Get(buttonEntity);
                Transform buttonTransform = buttonAnimationComponent.ButtonTransform;
                Vector3 buttonTransformLocalPosition = buttonTransform.localPosition;
                
                buttonTransformLocalPosition.y = buttonComponent.IsPressed ? buttonAnimationComponent.PressedYPosition : buttonAnimationComponent.DefaultYPosition;
                buttonTransform.localPosition = buttonTransformLocalPosition;
            }
            

        }
    }
}