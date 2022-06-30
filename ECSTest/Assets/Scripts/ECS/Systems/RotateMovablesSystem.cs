using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class RotateMovablesSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter movablesFilter = world.Filter<MovableComponent>().End();
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();
            
            foreach (int movableEntity in movablesFilter)
            {
                ref MovableComponent movableComponent = ref movablesPool.Get(movableEntity);
                if (movableComponent.IsMoving)
                {
                    movableComponent.Transform.localRotation = Quaternion.Lerp(movableComponent.Transform.localRotation, 
                        Quaternion.LookRotation(new Vector3(movableComponent.CurrentMovementDirection.x,0,movableComponent.CurrentMovementDirection.y)),
                        0.3f);
                }
            }
        }
    }
}