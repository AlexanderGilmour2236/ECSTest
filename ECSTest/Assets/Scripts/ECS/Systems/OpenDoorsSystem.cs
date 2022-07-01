using System;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace ECSTest
{
    public class OpenDoorsSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter doors = world.Filter<DoorComponent>().End();
            EcsFilter holdButtons = world.Filter<ButtonComponent>().End();
            EcsPool<DoorComponent> doorsPool = world.GetPool<DoorComponent>();
            EcsPool<ButtonComponent> holdButtonsPool = world.GetPool<ButtonComponent>();
            EcsPool<LocalPositionComponent> localPositionsPool = world.GetPool<LocalPositionComponent>();

            foreach (int doorEntity in doors)
            {
                DoorComponent doorComponent = doorsPool.Get(doorEntity);
                ref LocalPositionComponent doorLocalPositionComponent = ref localPositionsPool.Get(doorEntity);

                foreach (int holdButtonEntity in holdButtons)
                {
                    ref ButtonComponent buttonComponent = ref holdButtonsPool.Get(holdButtonEntity);

                    if (String.Compare(buttonComponent.ButtonId, doorComponent.DoorId, StringComparison.Ordinal) == 0
                        && buttonComponent.IsPressed)
                    {
                        if (doorLocalPositionComponent.LocalPosition.y > doorComponent.ClosedDoorYPosition)
                        {
                            doorLocalPositionComponent.LocalPosition += Vector3.down * doorComponent.OpenCloseSpeed * Time.deltaTime;
                        }
                    }
                    
                }
            }
        }
    }
}