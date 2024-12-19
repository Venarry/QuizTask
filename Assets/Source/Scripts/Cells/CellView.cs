using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Cells
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _symbol;
        [SerializeField] private Image _backgroundImage;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void Init(Sprite sprite, float size, float spriteAngle)
        {
            _symbol.sprite = sprite;
            _symbol.preserveAspect = true;
            _rectTransform.sizeDelta = new Vector2(size, size);
            _symbol.transform.localRotation = Quaternion.Euler(0, 0, -spriteAngle);

            float colorDivider = 255;
            float minColor = 170;
            float maxColor = 220;

            float r = Random.Range(minColor, maxColor) / colorDivider;
            float g = Random.Range(minColor, maxColor) / colorDivider;
            float b = Random.Range(minColor, maxColor) / colorDivider;

            _backgroundImage.color = new Color(r, g, b);
        }
    }
}