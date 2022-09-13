using Client.Components;
using Client.UnityComponents.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DeselectingSystem: IEcsRunSystem
    {
        private EcsFilter<SelectedFlag> _filter;
        private UnitSelectingService unitSelectingService;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (var index in _filter)
                {
                    ref var entity = ref _filter.GetEntity(index);
                    entity.Del<SelectedFlag>();

                    if (entity.Has<SpriteRendererLink>())
                    {
                        var spriteRenderer = entity.Get<SpriteRendererLink>().SpriteRenderer;
                        spriteRenderer.color = Color.white;
                    }
                }
            }
        }
    }
}