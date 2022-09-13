using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class SpriteRendererMonoLink : MonoLink<SpriteRendererLink>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<SpriteRendererLink>() = new SpriteRendererLink()
            {
                SpriteRenderer = _spriteRenderer
            };
        }
    }
}