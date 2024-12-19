using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Source.Scripts.Cells
{
    public class CellClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action<Vector3> Clicked;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3 clickPosition = transform.position;
            clickPosition.z = 0;

            Clicked?.Invoke(clickPosition);
        }
    }
}