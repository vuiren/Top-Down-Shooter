using System;
using _Scripts.Services;
using _Scripts.Systems.Player;
using Client.Components;
using Client.Systems;
using Client.Systems.Ground;
using Client.Systems.Wandering;
using Client.UnityComponents;
using Client.UnityComponents.Factory;
using Client.UnityComponents.MonoLinks;
using Client.UnityComponents.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private Configuration configuration;
        [SerializeField] private PrefabFactory prefabFactory;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private NavigationService navigationService;

        [SerializeField] private UnitSelectingService _selectingService;
        [SerializeField] private MousePositionService _mousePositionService;
        
        private EcsWorld _world;
        private EcsSystems _systems, _fixedSystems;

        private void Start ()
        {
            _sceneData.MonoEntities = FindObjectsOfType<MonoEntity>();
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _fixedSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_fixedSystems);
#endif
            
            _fixedSystems
                .Add(new Wander())
                .Add( SystemsCollection.GetNavigationSystems(_world))
                .Add(SystemsCollection.GetMoveSystems(_world))
                .Add(SystemsCollection.GetRotationSystems(_world))
                .Inject(_mousePositionService)
                .Inject(navigationService)
                .Inject(configuration)
                .Init();
            
            _systems
                .OneFrame<AttackCommandFlag>()
                .Add(new RegisterSceneMonoEntities())
                .Add(new SpawnSystem())
                .Add(new PlayerInputSystem())
                .Add(SystemsCollection.GetAttackSystems(_world))
                .Add(SystemsCollection.GetHealthSystems(_world))
                .Add(SystemsCollection.GetSelectSystems(_world))
                .Add(SystemsCollection.GetAnimationSystems(_world))
                .Add(SystemsCollection.GetDeathSystems(_world))
                .Add(SystemsCollection.GetBuildingSystems(_world))
                .Add(new SyncMonoLinks())
                .Add(new DestroyCollisionEvent())
                .Add(new DestroyOnAttackTargetDetectedSystem())

                .Inject(configuration)
                .Inject(navigationService)
                .Inject(_sceneData)
                .Inject(prefabFactory)
                .Inject(_selectingService)
                .Inject(_mousePositionService)
                .Init ();
        }

        private void Update () {
            _systems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedSystems?.Run();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}