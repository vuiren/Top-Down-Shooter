using System;
using Client.Extensions;
using UnityEngine;

namespace Client.UnityComponents
{
    public class DrawVelocity : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private LayerMask groundLayers;
        private void OnDrawGizmos()
        {
            var a = Physics2D.Raycast(root.position.Vector2() + Vector2.up, Vector2.down, 10, groundLayers);
            if(!a) return;
            var normal = a.normal;
            var newDirection = new Vector2(normal.y, -normal.x);
            Gizmos.DrawRay(root.position, newDirection);
        }
    }
}