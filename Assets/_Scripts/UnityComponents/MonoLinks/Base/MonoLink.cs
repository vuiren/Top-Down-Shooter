﻿using Leopotam.Ecs;

namespace Client.UnityComponents.MonoLinks
{
    public abstract class MonoLink<T> : MonoLinkBase where T : struct
    {
        public T Value;
        
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<T>() = Value;
        }
    }
}