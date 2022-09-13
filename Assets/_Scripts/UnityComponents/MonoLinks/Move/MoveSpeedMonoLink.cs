using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class MoveSpeedMonoLink: MonoLink<MoveSpeed>
    {
        [SerializeField] private float moveSpeed;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<MoveSpeed>() = new MoveSpeed()
            {
                Value = moveSpeed
            };
        }
    }
}