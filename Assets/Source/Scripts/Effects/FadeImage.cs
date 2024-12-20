using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Effects
{
    public class FadeImage : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _targetFadeValue = 50;

        private FadeEffect<Image> _fadeEffect;

        private void Awake()
        {
            _fadeEffect = new FadeEffect<Image>(_image, _targetFadeValue);
        }

        public void Show(float alpha = 0)
        {
            gameObject.SetActive(true);

            _fadeEffect.Set(alpha);
        }

        public async Task Turn()
        {
            await _fadeEffect.Turn();
        }

        public async Task Hide()
        {
            await _fadeEffect.Hide();

            gameObject.SetActive(false);
        }
    }
}