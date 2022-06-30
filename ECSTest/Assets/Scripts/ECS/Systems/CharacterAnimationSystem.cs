using Leopotam.EcsLite;

namespace ECSTest
{
    public class CharacterAnimationSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter animatedCharactersFilter =
                world.Filter<MovableComponent>().Inc<CharacterAnimationComponent>().End();

            EcsPool<CharacterAnimationComponent> animatedCharactersPool = world.GetPool<CharacterAnimationComponent>();
            EcsPool<MovableComponent> movablesPool = world.GetPool<MovableComponent>();

            foreach (int entity in animatedCharactersFilter)
            {
                CharacterAnimationComponent characterAnimationComponent = animatedCharactersPool.Get(entity);
                characterAnimationComponent.Animator.SetBool(characterAnimationComponent.WalkAnimationBoolName, movablesPool.Get(entity).IsMoving);
            }
        }
    }
}