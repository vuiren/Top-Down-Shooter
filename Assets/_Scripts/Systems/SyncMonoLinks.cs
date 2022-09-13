using Client.Components;
using Client.UnityComponents.MonoLinks;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class SyncMonoLinks: IEcsRunSystem
    {
        private EcsFilter<GameObjectLink, Position> _filter;
        private EcsFilter<GameObjectLink, Velocity> _filter2;
        private EcsFilter<GameObjectLink, AttackTarget> _filter3;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.Get1(index);
                var link = entity.Value.GetComponent<PositionMonoLink>();
                if(!link) continue;

                link.position = _filter.Get2(index).Value;
            }

            foreach (var index in _filter2)
            {
                var entity = _filter2.Get1(index);
                var link = entity.Value.GetComponent<VelocityMonoLink>();
                if(!link) continue;

                link.velocity = _filter2.Get2(index).Value;
            }

            foreach (var index in _filter3)
            {
                var entity = _filter3.Get1(index);
                var link = entity.Value.GetComponent<AttackTargetMonoLink>();
                if(!link) continue;
                link.Entity = _filter3.Get2(index).Value;
            }
        }
    }
}