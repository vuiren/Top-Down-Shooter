using Client.Components;
using Client.Components.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace _Scripts.Systems.Player
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerFlag> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var horizontal = Input.GetAxisRaw("Horizontal") * Vector2.right;
                var vertical = Input.GetAxisRaw("Vertical") * Vector2.up;
                ref var entity = ref _filter.GetEntity(index);

                if (Input.GetMouseButton(0))
                {
                    entity.Get<AttackCommandFlag>();
                }

                entity.Get<Velocity>() = new Velocity()
                {
                    Value = horizontal + vertical
                };
            }
        }
    }
}