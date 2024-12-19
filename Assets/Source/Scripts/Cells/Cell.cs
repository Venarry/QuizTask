using System;
using UnityEngine;

namespace Assets.Source.Scripts.Cells
{
    [RequireComponent(typeof(CellClickHandler))]
    [RequireComponent(typeof(CellView))]
    public class Cell : MonoBehaviour
    {
        private CellClickHandler _cellClickHandler;
        private CellView _cellView;

        public event Action<Cell> Clicked;

        public string Identificator { get; private set; }

        private void Awake()
        {
            _cellClickHandler = GetComponent<CellClickHandler>();
            _cellView = GetComponent<CellView>();
        }

        private void OnEnable()
        {
            _cellClickHandler.Clicked += OnClick;
        }

        public void Init(Sprite sprite, string identificator, float size, float sriteAngle)
        {
            _cellView.Init(sprite, size, sriteAngle);
            Identificator = identificator;
        }

        private void OnClick()
        {
            Clicked?.Invoke(this);
        }
    }
}