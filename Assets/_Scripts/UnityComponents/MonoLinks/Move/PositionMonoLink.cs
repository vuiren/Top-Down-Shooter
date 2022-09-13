using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class PositionMonoLink : MonoLink<Position>
    {
        public Vector2 position;

        public override void Make(ref EcsEntity entity)
        {
            position = transform.position;
            entity.Get<Position>() = new Position()
            {
                Value = position
            };
        }
    }
}