using UnityEngine;

namespace Assets.Source.Scripts.SO
{
    [CreateAssetMenu(fileName = "NewCell", menuName = "Quiz/Create cell")]
    public class CellSO : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private string _identificator = "A";
        [SerializeField] private float _spriteAngleOffset = 0;

        public Sprite Sprite => _sprite;
        public string Identificator => _identificator;
        public float SpriteAngleOffset => _spriteAngleOffset;
    }
}