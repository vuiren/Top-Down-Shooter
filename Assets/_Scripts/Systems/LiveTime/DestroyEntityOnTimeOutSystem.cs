using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class DestroyEntityOnTimeOutSystem: IEcsRunSystem
    {
        private EcsFilter<LiveTime> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var entity = ref _filter.GetEntity(index);
                var liveTime = _filter.Get1(index);

                if (liveTime.RemainingTime < 0)
                {
                    entity.Get<DeathFlag>();
                }
            }
        }
    }
}