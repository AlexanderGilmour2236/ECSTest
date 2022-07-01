using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public class PointToClickInputSystem : IEcsRunSystem
    {
        private const float MIN_DISTANCE_TO_POINT = 0.4f;
        
        private Vector2? _mouseClickPoint;

        public void Run(EcsSystems systems)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    _mouseClickPoint = new Vector2(hit.point.x, hit.point.z);
                }
            }

            if (_mouseClickPoint == null)
            {
                return;
            }
            
            EcsWorld world = systems.GetWorld();
            EcsFilter movableEntities = world.Filter<MovableComponent>().Inc<InputEventComponent>().Inc<LocalPositionComponent>().End();
            
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();
            EcsPool<InputEventComponent> inputEventsPool = world.GetPool<InputEventComponent>();
            EcsPool<LocalPositionComponent> worldPositionsPool = world.GetPool<LocalPositionComponent>();
        
            foreach (int entity in movableEntities)
            {
                ref InputEventComponent inputEventComponent = ref inputEventsPool.Get(entity);
                ref MovableComponent movableComponent = ref movablesPool.Get(entity);
                ref LocalPositionComponent localPositionComponent = ref worldPositionsPool.Get(entity);

                Vector2 movableComponentPosition = new Vector2(localPositionComponent.LocalPosition.x,
                    localPositionComponent.LocalPosition.z);
                
                float distance = Vector2.Distance(movableComponentPosition, _mouseClickPoint.Value);
                if (Mathf.Abs(distance) > MIN_DISTANCE_TO_POINT)
                {
                    Vector3 movablePosition = localPositionComponent.LocalPosition;
                    inputEventComponent.MoveDirection = (_mouseClickPoint.Value - new Vector2(movablePosition.x, movablePosition.z)).normalized;
                }
                else
                {
                    _mouseClickPoint = null;
                    inputEventComponent.MoveDirection = Vector2.zero;
                }
            }
        }
    }
}