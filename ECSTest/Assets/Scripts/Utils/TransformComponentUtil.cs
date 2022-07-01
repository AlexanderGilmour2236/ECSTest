using Leopotam.EcsLite;
using UnityEngine;

namespace ECSTest
{
    public static class TransformComponentUtil
    {
        public static void InitTransformForEntity(int playerEntity, Transform transform,
            EcsPool<TransformComponent> transformsPool, EcsPool<LocalPositionComponent> localPositionsPool)
        {
            ref TransformComponent transformComponent = ref transformsPool.Add(playerEntity);
            transformComponent.Transform = transform;

            ref LocalPositionComponent localPositionComponent = ref localPositionsPool.Add(playerEntity);
            localPositionComponent.LocalPosition = transformComponent.Transform.position;
            localPositionComponent.LocalRotation = transformComponent.Transform.rotation;
        }
    }
}