using Client.Components;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class ShootSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Weapon, AttackTarget> _filter;
        private Configuration _configuration;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);

                var attackTarget = _filter.Get2(index);
                if (attackTarget.Value.IsNull()) continue;

                ref var weapon = ref _filter.Get1(index);
                if (weapon.remainingDelay > 0) continue;

                if (entity.Has<FollowingAttackTargetFlag>())
                {
                    continue;
                }

                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab()
                {
                    Prefab = weapon.WeaponSo.ProjectilePrefab,
                    Parent = null,
                    Position = weapon.bulletSpawnPoint.position,
                    Rotation = weapon.bulletSpawnPoint.rotation
                };
                weapon.remainingDelay = weapon.WeaponSo.TimeBetweenShots;
            }
        }
    }
}