using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class UpdateRigidBodyPositionSystem: IEcsRunSystem
    {
        private EcsFilter<RigidBodyLink, Position> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var rb = _filter.Get1(index);
                var position = _filter.Get2(index);
                rb.Value.MovePosition(position.Value);
            }
        }
    }
}