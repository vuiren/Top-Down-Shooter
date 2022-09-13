using UnityEngine;

namespace Client.Components
{
    public struct SpawnPrefab
    {
        public GameObject Prefab;
        public Vector2 Position;
        public Quaternion Rotation;
        public Transform Parent;
    }
}