using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class VelocityMonoLink: MonoLink<Velocity>
    {
        public Vector2 velocity;
        
        public override void Make(ref EcsEntity entity)
        {
            velocity = transform.TransformDirection(velocity);
            entity.Get<Velocity>() = new Velocity()
            {
                Value = velocity
            };
        }
    }
}