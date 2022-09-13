using Client.Components;
using Leopotam.Ecs;

namespace Client.UnityComponents.MonoLinks
{
    public class EnemyFlagMonoLink: MonoLink<EnemyFlag>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<EnemyFlag>() = new EnemyFlag();
        }
    }
}