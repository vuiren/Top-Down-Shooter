using System;
using Client.Components;
using Client.Extensions;
using Client.UnityComponents.MonoLinks;
using UnityEngine;

namespace Client.UnityComponents.Util
{
    public static class DATA
    {
        public static Vector2 velocity;
    }

    public class ShowAss : MonoBehaviour
    {
        [SerializeField] private VelocityMonoLink monoLink;
        [SerializeField] private float radius;
        [SerializeField] private LayerMask mask;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, DATA.velocity * 100);
        }
    }
}