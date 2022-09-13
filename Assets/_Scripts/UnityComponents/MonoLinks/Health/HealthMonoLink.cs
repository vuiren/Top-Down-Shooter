using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class HealthMonoLink: MonoLink<Health>
    {
        [SerializeField] private int healthCount;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<Health>() = new Health()
            {
                Value = healthCount
            };
        }
    }
}