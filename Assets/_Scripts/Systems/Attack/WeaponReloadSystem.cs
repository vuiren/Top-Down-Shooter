using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class WeaponReloadSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter<Weapon> _filter;
        
        public void Init()
        {
            foreach (var index in _filter)
            {
                ref var weapon = ref _filter.Get1(index);
                weapon.remainingDelay = 0.5f;
            }
        }
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var weapon = ref _filter.Get1(index);
                if (weapon.remainingDelay > -1)
                    weapon.remainingDelay -= Time.deltaTime;
            }
        }


    }
}