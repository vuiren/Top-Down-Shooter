using Client.UnityComponents;
using UnityEngine;

namespace Client.Components
{
    public struct Weapon
    {
        public WeaponSO WeaponSo;
        public Transform bulletSpawnPoint;
        public float remainingDelay;
    }
}