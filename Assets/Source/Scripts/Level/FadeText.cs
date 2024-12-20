using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Source.Scripts.Level
{
    [RequireComponent(typeof(TMP_Text))]
    public class FadeText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        private float _targetFadeValue = 255;
        private FadeEffect<TMP_Text> _fadeEffect;

        private void Awake()
        {
            _fadeEffect = new FadeEffect<TMP_Text>(_label, _targetFadeValue);
        }

        public void SetText(string text)
        {
            _label.text = text;
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