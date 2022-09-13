using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class LiveTimerSystem: IEcsRunSystem
    {
        private EcsFilter<LiveTime> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var time = ref _filter.Get1(index);
                time.RemainingTime -= Time.deltaTime;
            }
        }
    }
}