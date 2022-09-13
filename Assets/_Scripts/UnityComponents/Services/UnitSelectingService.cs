using System;
using Client.UnityComponents.MonoLinks;
using UnityEngine;

namespace Client.UnityComponents.Services
{
    public class UnitSelectingService : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask unitLayers;

        public MonoEntity SelectedUnit;
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                SelectedUnit = null;
                return;
            }
            
            var point = _camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(point, Vector2.zero, 100f, unitLayers);
            Debug.Log("No hit");
            if (!hit) return;
            Debug.Log($"Hit {hit.transform.gameObject}");

            var entity = hit.transform.gameObject.GetComponentInParent<MonoEntity>();
            if (entity)
            {
                SelectedUnit = entity;
            }
        }
    }
}