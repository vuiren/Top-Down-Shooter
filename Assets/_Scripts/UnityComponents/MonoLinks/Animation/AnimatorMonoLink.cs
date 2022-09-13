using Client.Components.Animation;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks.Animation
{
    public class AnimatorMonoLink : MonoLink<AnimatorLink>
    {
        [SerializeField] private Animator Animator;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<AnimatorLink>() = new AnimatorLink()
            {
                Animator = Animator
            };
        }
    }
}