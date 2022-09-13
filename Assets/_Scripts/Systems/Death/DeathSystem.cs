using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DeathSystem: IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, DeathFlag> _filter;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);

                var link = entity.Get<GameObjectLink>();
                if (link.Value)
                {
                    GameObject.Destroy(link.Value);
                }
                entity.Destroy();
            }
        }
    }
}