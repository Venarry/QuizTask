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
        Color startColor = _image.color;
        Color targetColor = _image.color;

        float maxColorValue = 255;
        targetColor.a = _targetFadeValue / maxColorValue;

        await FadeTo(startColor, targetColor);
    }

    public void Show(float alpha = 0)
    {
        gameObject.SetActive(true);

        Color imageColor = _image.color;
        imageColor.a = alpha;
        _image.color = imageColor;
    }

    public async Task Hide()
    {
        Color startColor = _image.color;
        Color targetColor = _image.color;
        targetColor.a = 0;

        await FadeTo(startColor, targetColor);

        gameObject.SetActive(false);
    }

    private async Task FadeTo(Color startColor, Color targetColor)
    {
        float timer = 0;

        while (timer < _fadeDuration)
        {
            float progress = timer / _fadeDuration;
            _image.color = Color.Lerp(startColor, targetColor, progress);
            timer += Time.deltaTime;

            await Task.Yield();
        }
    }
}
