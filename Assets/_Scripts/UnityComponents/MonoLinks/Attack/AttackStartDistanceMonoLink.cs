using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class AttackStartDistanceMonoLink : MonoLink<AttackStartDistance>
    {
        [SerializeField] private float distance;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<AttackStartDistance>() = new AttackStartDistance()
            {
                Value = distance
            };
        }
    }
}