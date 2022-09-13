using System;
using UnityEngine;

namespace Client.UnityComponents
{
    public enum BuildingTypes
    {
        Casarm,
        Barricade
    }
    
    [Serializable]
    public class BuildingData
    {
        public BuildingTypes buildingTypes;
        public GameObject previewBuildingPrefab, buildingPrefab;
    }
    
    [CreateAssetMenu(fileName = "New Configuration", menuName = "Add Configuration", order = 0)]
    public class Configuration : ScriptableObject
    {
        public GameObject explosionPrefab;
        public LayerMask GroundLayers;
        public WeaponSO[] WeaponSos;
        public BuildingData[] BuildingDatas;
    }
}