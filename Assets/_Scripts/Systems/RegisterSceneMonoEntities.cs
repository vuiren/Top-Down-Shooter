using Client.UnityComponents;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class RegisterSceneMonoEntities: IEcsInitSystem
    {
        private EcsWorld _world;
        private SceneData _sceneData;
        public void Init()
        {
            foreach (var monoEntity in _sceneData.MonoEntities)
            {
                var entity = _world.NewEntity();
                monoEntity.Make(ref entity);
            }
        }
    }
}