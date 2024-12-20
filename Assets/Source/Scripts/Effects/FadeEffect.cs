using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Effects
{
    public class FadeEffect<T> where T : MaskableGraphic
    {
        private readonly T _graphic;
        private readonly float _targetFadeValue = 50;

        private readonly float _fadeDuration = 1f;

        public FadeEffect(T graphic, float targetFadeValue = 255f, float fadeDuration = 1f)
        {
            _graphic = graphic;
            _targetFadeValue = targetFadeValue;
            _fadeDuration = fadeDuration;
        }

        public async Task Turn()
        {
            Color startColor = _graphic.color;
            Color targetColor = _graphic.color;

            float maxColorValue = 255;
            targetColor.a = _targetFadeValue / maxColorValue;

            await FadeTo(startColor, targetColor);
        }

        public void Set(float alpha)
        {
            Color color = _graphic.color;
            color.a = alpha;
            _graphic.color = color;
        }

        public async Task Hide()
        {
            Color startColor = _graphic.color;
            Color targetColor = _graphic.color;
            targetColor.a = 0;

            await FadeTo(startColor, targetColor);
        }

        private async Task FadeTo(Color startColor, Color targetColor)
        {
            float timer = 0;

            while (timer < _fadeDuration)
            {
                float progress = timer / _fadeDuration;
                _graphic.color = Color.Lerp(startColor, targetColor, progress);
                timer += Time.deltaTime;

                await Task.Yield();
            }
        }
    }
}