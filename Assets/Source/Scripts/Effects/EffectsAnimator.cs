using UnityEngine;

public class EffectsAnimator : MonoBehaviour
{
    private const string NameBounceAnimation = "Bounce";
    private const string NameEaseInBounceAnimation = "EaseInBounce";

    [SerializeField] private Animator _cellAnimator;
    [SerializeField] private Animator _symbolAnimator;

    public void StartBounce()
    {
        _cellAnimator.CrossFadeInFixedTime(NameBounceAnimation, 0.1f);
    }

    public void StartEaseInBounce()
    {
        _symbolAnimator.CrossFadeInFixedTime(NameEaseInBounceAnimation, 0.1f);
    }
}
