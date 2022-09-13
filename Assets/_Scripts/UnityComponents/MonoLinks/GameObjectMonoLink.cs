using Client.Components;
using Leopotam.Ecs;

namespace Client.UnityComponents.MonoLinks
{
    public class GameObjectMonoLink : MonoLink<GameObjectLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<GameObjectLink>() = new GameObjectLink()
            {
                Value = gameObject
            };
        }
    }
}