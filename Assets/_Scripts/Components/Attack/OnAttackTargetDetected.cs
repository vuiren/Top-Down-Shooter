using Leopotam.Ecs;

namespace Client.Components
{
    public struct OnAttackTargetDetected
    {
        public EcsEntity DetectedTarget, Sender;
    }
}