using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class OpenDoorsSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter doors = world.Filter<DoorComponent>().End();
            EcsFilter holdButtons = world.Filter<HoldButtonComponent>().End();
            EcsPool<DoorComponent> doorsPool = world.GetPool<DoorComponent>();
            EcsPool<HoldButtonComponent> holdButtonsPool = world.GetPool<HoldButtonComponent>();

            foreach (int doorEntity in doors)
            {
                DoorComponent doorComponent = doorsPool.Get(doorEntity);
                foreach (int holdButtonEntity in holdButtons)
                {
                    ref HoldButtonComponent holdButtonComponent = ref holdButtonsPool.Get(holdButtonEntity);
                    if (String.Compare(holdButtonComponent.ButtonId, doorComponent.DoorId, StringComparison.Ordinal) == 0
                        && holdButtonComponent.IsPressed)
                    {
                        doorComponent.DoorTransform.Translate(Vector3.down * doorComponent.OpenCloseSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }
}