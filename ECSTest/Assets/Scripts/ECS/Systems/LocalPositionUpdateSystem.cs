using Leopotam.EcsLite;

namespace ECSTest
{
    public class LocalPositionUpdateSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter transformsFilter = world.Filter<TransformComponent>().Inc<LocalPositionComponent>().End();
            EcsPool<TransformComponent> transformsPool = world.GetPool<TransformComponent>();
            EcsPool<LocalPositionComponent> worldPositionsPool = world.GetPool<LocalPositionComponent>();

            foreach (int entity in transformsFilter)
            {
                transformsPool.Get(entity).Transform.localPosition = worldPositionsPool.Get(entity).LocalPosition;
                transformsPool.Get(entity).Transform.localRotation = worldPositionsPool.Get(entity).LocalRotation;
            }
        }
    }
}