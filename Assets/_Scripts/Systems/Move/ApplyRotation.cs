using System.Linq;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class ApplyRotation : IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, Components.Rotation> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var gameObjectLink = _filter.Get1(index);
                var rotation = _filter.Get2(index);
                var smooth =
                    Quaternion.Lerp(gameObjectLink.Value.transform.rotation, rotation.Value,
                        1f); //5f * Time.fixedDeltaTime);
                gameObjectLink.Value.transform.rotation = smooth;
            }
        }
    }
}