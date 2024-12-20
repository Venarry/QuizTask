using Assets.Source.Scripts.Effects;
using System;
using UnityEngine;

namespace Assets.Source.Scripts.Cells
{
    [RequireComponent(typeof(CellClickHandler))]
    [RequireComponent(typeof(CellView))]
    [RequireComponent(typeof(EffectsAnimator))]
    public class Cell : MonoBehaviour
    {
        private CellClickHandler _cellClickHandler;
        private CellView _cellView;
        private EffectsAnimator _bounceEffect;

        public event Action<Cell, Vector3> Clicked;

        public string Identificator { get; private set; }

        private void Awake()
        {
            _cellClickHandler = GetComponent<CellClickHandler>();
            _cellView = GetComponent<CellView>();
            _bounceEffect = GetComponent<EffectsAnimator>();
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

        public void StartCellBounceEffect()
        {
            _bounceEffect.StartCellBounce();
        }

        public void StartSymbolEaseInBounce()
        {
            _bounceEffect.StartSymbolEaseInBounce();
        }

        public void StartSymbolBounceEffect()
        {
            _bounceEffect.StartSymbolBounceEffect();
        }

        private void OnClick(Vector3 clickPosition)
        {
            Clicked?.Invoke(this, clickPosition);
        }
    }
}