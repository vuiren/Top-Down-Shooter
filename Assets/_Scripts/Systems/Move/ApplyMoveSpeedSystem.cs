using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ApplyMoveSpeedSystem: IEcsRunSystem
    {
        private EcsFilter<MoveSpeed, Velocity> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var moveSpeed = _filter.Get1(index);
                ref var velocity = ref _filter.Get2(index);

                velocity.Value = velocity.Value.normalized * moveSpeed.Value;
            }
        }
    }
}