using Assets.Source.Scripts.SO;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Scripts.Infrastructure
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private string _name;
        [SerializeField] LevelSO[] _level;

        public LevelSO[] Level => _level.ToArray();
    }
}