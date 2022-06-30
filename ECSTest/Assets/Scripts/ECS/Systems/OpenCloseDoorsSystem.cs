using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class OpenCloseDoorsSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter doors = world.Filter<DoorComponent>().End();
            EcsFilter holdButtons = world.Filter<ButtonComponent>().End();
            EcsPool<DoorComponent> doorsPool = world.GetPool<DoorComponent>();
            EcsPool<ButtonComponent> holdButtonsPool = world.GetPool<ButtonComponent>();

            foreach (int doorEntity in doors)
            {
                DoorComponent doorComponent = doorsPool.Get(doorEntity);
                foreach (int holdButtonEntity in holdButtons)
                {
                    ref ButtonComponent buttonComponent = ref holdButtonsPool.Get(holdButtonEntity);
                    foreach (string buttonId in buttonComponent.ButtonIds)
                    {
                        if (String.Compare(buttonId, doorComponent.DoorId, StringComparison.Ordinal) == 0
                            && buttonComponent.IsPressed)
                        {
                            if (buttonComponent.ButtonActionType == ButtonActionType.OpenDoor && 
                                doorComponent.DoorTransform.localPosition.y > doorComponent.ClosedDoorYPosition)
                            {
                                doorComponent.DoorTransform.Translate(Vector3.down * doorComponent.OpenCloseSpeed * Time.deltaTime);
                            }
                            
                            if (buttonComponent.ButtonActionType == ButtonActionType.CloseDoor && 
                                doorComponent.DoorTransform.localPosition.y < doorComponent.OpenDoorYPosition)
                            {
                                doorComponent.DoorTransform.Translate(Vector3.up * doorComponent.OpenCloseSpeed * Time.deltaTime);
                            }
                        }
                    }
                }
            }
        }
    }
}