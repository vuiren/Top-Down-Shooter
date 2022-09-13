using _Scripts.Systems.Build;
using _Scripts.Systems.Navigation;
using _Scripts.Systems.Player;
using Client.Components;
using Client.Components.Build;
using Client.Systems.Animation;
using Client.Systems.Build;
using Client.Systems.Collisions;
using Client.Systems.Commands;
using Client.Systems.Ground;
using Client.Systems.Rotation;
using Leopotam.Ecs;

namespace Client.Systems
{
    public static class SystemsCollection
    {
        public static EcsSystems GetAttackSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new DestroyEmptyDetectedAttackTargetsSystem())
                .Add(new PreventOnAttackTargetDetectedDoublingEvent())
                .Add(new DetectAttackTargetSystem())
                .Add(new FollowAttackTargetSystem())
                .Add(new StopFollowingAttackTargetSystem())
                .Add(new MoveToAttackTargetSystem())
                .Add(new StopMovingOnAttackTargetDetectionSystem())
                .Add(new AimAtAttackTarget())
                .Add(new ShootSystem())
                .Add(new ShootByCommand())
                .Add(new DestroyProjectilesOnCollisionSystem())
                .Add(new WeaponReloadSystem())
                .Add(new LiveTimerSystem())
                .Add(new DestroyEntityOnTimeOutSystem());
        }

        public static EcsSystems GetAnimationSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new UpdateUnitStateSystem())
                .Add(new AnimateUnitSystem());
        }

        public static EcsSystems GetHealthSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new DetectDamageSystem())
                .Add(new SyncHealthText())
                .Add(new ApplyBlinkEffectSystem())
                .Add(new DamageBlinkEffectReduceTimeSystem())
                .Add(new DamageBlinkSystem())
                .Add(new ApplyDamageSystem());
        }

        public static EcsSystems GetMoveSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new MoveToCursorSystem())
                .Add(new MoveToMoveTargetSystem())
                .Add(new KeepDistanceFromAttackTargetSystem())
                //   .Add(new StickEntityToTheGroundSystem())
                .Add(new ApplyMoveSpeedSystem())
                // .Add(new StopMovementIntoColliders())
                .Add(new SlideOnColliders())
                //.Add(new StopFromWalkingIntoWalls())
                .Add(new MoveSystem())
                .Add(new UpdateRigidBodyPositionSystem())
                .Add(new ApplyRotation())
                .Add(new DeleteMoveTargetOnArrivalForUnitsSystem());
        }

        public static EcsSystems GetRotationSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new LookAtMoveTargetSystem())
                .Add(new LookAtCursor())
                .Add(new LookAtAttackTargetSystem())
                .Add(new ApplyRotation());
        }

        public static EcsSystems GetDeathSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new ExplodeExplosiveOnDeathSystem())
                .Add(new DeathDetectSystem())
                .Add(new DeathSystem());
        }

        public static EcsSystems GetBuildingSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .OneFrame<OnBuildModeEnter>()
                .OneFrame<OnBuildModeExit>()
                .OneFrame<OnBuildPreviewChanged>()
                .Add(new ExitBuildMode())
                .Add(new EnterBuildModeSystem())
                .Add(new SelectNextBuilding())
                .Add(new DestroyBuildingPreviewsSystem())
                .Add(new ReplaceBuildingPreview())
                .Add(new CreateBuildPreviewSystem())
                .Add(new FindTheGroundPointForBuildingPreviewSystem())
                .Add(new StickBuildingPreviewToTheGroundSystem())
                .Add(new RotateBuildingPreview())
                .Add(new PlaceBuilding());
        }

        public static EcsSystems GetSelectSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                .Add(new DeselectingSystem())
                .Add(new SelectUnitSystem())
                .Add(new PaintSelectedSystem());
        }

        public static EcsSystems GetNavigationSystems(EcsWorld world)
        {
            return new EcsSystems(world)
                    .Add(new SetPath())
                    .Add(new FollowPath())
                    .Add(new RemoveEmptyPath())
                ;
        }
    }
}