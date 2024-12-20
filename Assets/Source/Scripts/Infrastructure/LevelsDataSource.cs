using Assets.Source.Scripts.SO;
using UnityEngine;
using System.Linq;

namespace Assets.Source.Scripts.Infrastructure
{
    public class LevelsDataSource : MonoBehaviour
    {
        [SerializeField] private LevelData[] _levels;

        public LevelSO[][] GetAll()
        {
            return _levels.Select(levelData => levelData.Level).ToArray();
        }
    }
}