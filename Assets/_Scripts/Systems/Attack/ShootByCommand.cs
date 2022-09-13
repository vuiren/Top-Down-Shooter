using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class ShootByCommand: IEcsRunSystem
    {
        private EcsWorld _world;
        private EcsFilter<Weapon, AttackCommandFlag> _filter;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                
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