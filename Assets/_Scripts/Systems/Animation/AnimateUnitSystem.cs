using System;
using Client.Components.Animation;
using Leopotam.Ecs;

namespace Client.Systems.Animation
{
    public class AnimateUnitSystem: IEcsRunSystem
    {
        private EcsFilter<AnimatorLink, UnitState> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var animator = _filter.Get1(index).Animator;
                var state = _filter.Get2(index);
                switch (state.Value)
                {
                    case UnitStateEnum.Idle:
                        animator.Play("Idle");
                        break;
                    case UnitStateEnum.Shoot:
                        animator.Play("Shoot");
                        break;
                    case UnitStateEnum.Walk:
                        animator.Play("Walk");
                        break;
                    default:
                        animator.Play("Idle");
                        break;
                }
            }
        }
    }
}