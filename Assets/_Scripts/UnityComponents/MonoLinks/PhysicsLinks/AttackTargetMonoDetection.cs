using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class AttackTargetMonoDetection : PhysicLinkBase
    {
        [SerializeField] private float attackStartDistance;
        [SerializeField] private bool requireRaycast;
        [SerializeField] private LayerMask targetsLayers;
        private void OnTriggerEnter2D(Collider2D col)
        {
            UpdateAttackTarget(col.gameObject);
        }

        private void UpdateAttackTarget(GameObject col)
        {
            var distance = Vector2.Distance(col.transform.position, gameObject.transform.position);
            if(distance > attackStartDistance) return;
            var a = (targetsLayers.value & (1 << col.gameObject.layer)) > 0;
            if (!a)
            {
                return;
            }

            if (requireRaycast)
            {
                var hit = Physics2D.Linecast(transform.position, col.transform.position, targetsLayers);
                if(hit) return;
            }
            
            var monoEntity = col.gameObject.GetComponentInParent<MonoEntity>();
            if(!monoEntity) return;
            
            _entity.Get<OnAttackTargetDetected>() = new OnAttackTargetDetected()
            {
                Sender = _entity,
                DetectedTarget = monoEntity._entity
            };
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            UpdateAttackTarget(other.gameObject);
        }
    }
}