using Client.Components;
using Leopotam.Ecs;

namespace Client.UnityComponents.MonoLinks
{
    public class AttackTargetMonoLink: MonoLink<AttackTarget>
    {
        public EcsEntity Entity;
    }
}