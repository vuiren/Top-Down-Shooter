using UnityEngine;

namespace Client.UnityComponents
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Add Weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        public GameObject ProjectilePrefab;
        public float TimeBetweenShots;
    }
}