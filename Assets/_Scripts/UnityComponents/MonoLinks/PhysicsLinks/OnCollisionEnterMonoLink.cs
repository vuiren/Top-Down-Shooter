using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class OnCollisionEnterMonoLink : PhysicLinkBase
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            _entity.Get<OnCollisionEnterEvent>() = new OnCollisionEnterEvent()
            {
                Collision = col,
                Sender = gameObject
            };
        }
    }
}