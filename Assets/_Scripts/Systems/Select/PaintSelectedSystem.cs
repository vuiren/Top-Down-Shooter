using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class PaintSelectedSystem: IEcsRunSystem
    {
        private EcsFilter<SelectedFlag, SpriteRendererLink> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var sprite = _filter.Get2(index);
                
                sprite.SpriteRenderer.color = Color.red;
            }
        }
    }
}