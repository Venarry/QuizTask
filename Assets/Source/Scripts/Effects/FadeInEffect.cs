using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _targetFadeValue = 50;

    private readonly float _fadeDuration = 1f;

    public async Task Turn()
    {
        float timer = 0;
        Color startColor = _image.color;
        Color targetColor = _image.color;

        float maxColorValue = 255;
        targetColor.a = _targetFadeValue / maxColorValue;

        while (timer < _fadeDuration)
        {
            float progress = timer / _fadeDuration;
            _image.color = Color.Lerp(startColor, targetColor, progress);
            timer += Time.deltaTime;

            await Task.Yield();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);

        Color imageColor = _image.color;
        imageColor.a = 0;
        _image.color = imageColor;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator Fading()
    {
        float timer = 0;
        Color targetColor = _image.color;

        float maxColorValue = 255;
        targetColor.a = _targetFadeValue / maxColorValue;

        while (timer < _fadeDuration)
        {
            float progress = timer / _fadeDuration;
            _image.color = Color.Lerp(_image.color, targetColor, progress);
            timer += Time.deltaTime;

            yield return null;
        }
    }
}
