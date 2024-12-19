using Assets.Source.Scripts.Configs;
using Assets.Source.Scripts.SO;
using UnityEngine;

namespace Assets.Source.Scripts.Cells
{
    public class CellFactory
    {
        private readonly Cell _prefab = Resources.Load<Cell>(ResourcesPath.Cell);

        public Cell Create(CellSO cellSO, Vector3 position, float size, Transform parent)
        {
            Cell cell = Object.Instantiate(_prefab, parent);

            cell.transform.localPosition = position;
            cell.Init(cellSO.Sprite, cellSO.Identificator, size, cellSO.SpriteAngleOffset);

            return cell;
        }
    }
}