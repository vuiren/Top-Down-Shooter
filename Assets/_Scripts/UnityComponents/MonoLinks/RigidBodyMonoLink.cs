using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class RigidBodyMonoLink : MonoLink<RigidBodyLink>
    {
        [SerializeField] private Rigidbody2D rb;
        
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<RigidBodyLink>() = new RigidBodyLink()
            {
                Value = rb
            };
        }
    }
}