using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class WeaponMonoLink : MonoLink<Weapon>
    {
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private WeaponSO WeaponSo;
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<Weapon>() = new Weapon()
            {
                bulletSpawnPoint = projectileSpawnPoint,
                WeaponSo = WeaponSo
            };
        }
    }
}