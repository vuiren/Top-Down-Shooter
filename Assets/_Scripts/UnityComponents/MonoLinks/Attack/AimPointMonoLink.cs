using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class AimPointMonoLink: MonoLink<AimPoint>
    {
        [SerializeField] private Transform aimPoint;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<AimPoint>() = new AimPoint()
            {
                Value = aimPoint
            };
        }
    }
}