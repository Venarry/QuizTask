using UnityEngine;

namespace Assets.Source.Scripts.Effects
{
    public class EffectsAnimator : MonoBehaviour
    {
        private const string NameBounceAnimation = "Bounce";
        private const string NameEaseInBounceAnimation = "EaseInBounce";

        [SerializeField] private Animator _cellAnimator;
        [SerializeField] private Animator _symbolAnimator;

        private readonly float _transitionDuration = 0.1f;

        public void StartCellBounce()
        {
            _cellAnimator.CrossFadeInFixedTime(NameBounceAnimation, _transitionDuration);
        }

        public void StartSymbolEaseInBounce()
        {
            _symbolAnimator.CrossFadeInFixedTime(NameEaseInBounceAnimation, _transitionDuration);
        }

        public void StartSymbolBounceEffect()
        {
            _symbolAnimator.CrossFadeInFixedTime(NameBounceAnimation, _transitionDuration);
        }
    }
}