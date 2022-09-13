using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class BulletSpawnPointMonoLink: MonoLink<BulletSpawnPoint>
    {
        [SerializeField] private Transform spawnPoint;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<BulletSpawnPoint>() = new BulletSpawnPoint()
            {
                Value = spawnPoint
            };
        }
    }
}