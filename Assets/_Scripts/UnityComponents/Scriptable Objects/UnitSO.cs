using UnityEngine;

namespace Client.UnityComponents
{
    [CreateAssetMenu(fileName = "New Unit Data", menuName = "Add Unit Data", order = 0)]
    public class UnitSO : ScriptableObject
    {
        public int Health;
        public float MoveSpeed;
    }
}