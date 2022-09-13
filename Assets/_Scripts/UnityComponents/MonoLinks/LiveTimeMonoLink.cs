using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks
{
    public class LiveTimeMonoLink : MonoLink<LiveTime>
    {
        [SerializeField] private float liveTime;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<LiveTime>() = new LiveTime()
            {
                RemainingTime = liveTime
            };
        }
    }
}