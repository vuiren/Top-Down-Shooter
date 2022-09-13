using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class CollisionMaskMonoLink : MonoLink<CollisionData>
    {
        [SerializeField] private float collisionRadius;
        [SerializeField] private LayerMask layerMask;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<CollisionData>() = new CollisionData()
            {
                CollisionRadius = collisionRadius,
                CollisionMask = layerMask
            };
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, collisionRadius);
        }
    }
}