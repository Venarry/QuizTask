using Assets.Source.Scripts.Configs;
using Assets.Source.Scripts.SO;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.Infrastructure
{
    public class LevelsDataSource
    {
        private readonly LevelSO[] _levelsSO = Resources.LoadAll<LevelSO>(ResourcesPath.Levels);

        public LevelSO[] GetAll() => _levelsSO.ToArray();
    }
}