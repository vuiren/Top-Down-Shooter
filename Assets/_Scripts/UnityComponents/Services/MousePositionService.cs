using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Client.UnityComponents.Services
{
    public class MousePositionService : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Tilemap tilemap;
        public Vector2 CursorPosition;

        private void Update()
        {
            CursorPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(tilemap.WorldToCell(CursorPosition));
            }
        }
    }
}