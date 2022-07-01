using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;

namespace ECSTest
{
    public class PointToClickInputSystem : IEcsRunSystem
    {
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
            EcsPool<MouseClickEventComponent> mouseClickEventsPool = world.GetPool<MouseClickEventComponent>();
            int mouseClickEventEntity = world.NewEntity();
            ref MouseClickEventComponent mouseClickEventComponent = ref mouseClickEventsPool.Add(mouseClickEventEntity);
            mouseClickEventComponent.Position = _mouseClickPoint.Value;
        }
    }
}