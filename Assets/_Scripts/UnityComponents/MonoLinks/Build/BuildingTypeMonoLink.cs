using Client.Components.Build;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents.MonoLinks.Build
{
    public class BuildingTypeMonoLink: MonoLink<BuildingType>
    {
        [SerializeField] private BuildingTypes _buildingType;

        public override void Make(ref EcsEntity entity)
        {
            entity.Get<BuildingType>() = new BuildingType()
            {
                Value = _buildingType
            };
        }
    }
}