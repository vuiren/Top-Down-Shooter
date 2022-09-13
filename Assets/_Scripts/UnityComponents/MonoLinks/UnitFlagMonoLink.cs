using Client.Components;
using Leopotam.Ecs;

namespace Client.UnityComponents.MonoLinks
{
    public class UnitFlagMonoLink: MonoLink<UnitFlag>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<UnitFlag>() = new UnitFlag();
        }
    }
}