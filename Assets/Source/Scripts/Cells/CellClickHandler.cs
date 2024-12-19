using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Source.Scripts.Cells
{
    public class CellClickHandler : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}