using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class PhysicLinkBase: MonoLinkBase
    {
        protected EcsEntity _entity;
        public override void Make(ref EcsEntity entity)
        {
            _entity = entity;
        }
    }
}