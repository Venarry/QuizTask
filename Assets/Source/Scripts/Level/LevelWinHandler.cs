using Assets.Source.Scripts.Cells;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Level
{
    public class LevelWinHandler : MonoBehaviour
    {
        private const float NextButtonShowDelay = 2f;
        private const string FindConditionText = "Find";

        [SerializeField] private Image _blackPanel;
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private TMP_Text _winConditionText;

        private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(NextButtonShowDelay);

        private LevelGenerator _levelGenerator;
        private IWinCondition _winCondition;
        private GameRestarter _gameRestarter;
        private string _winIdentificator;
        private Cell[] _activeCells;

        private void OnEnable()
        {
            _nextLevelButton.onClick.AddListener(OnNextButtonClick);
            _restartGameButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnDisable()
        {
            _nextLevelButton.onClick.RemoveListener(OnNextButtonClick);
            _restartGameButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        public void Init(LevelGenerator levelGenerator, IWinCondition winCondition, GameRestarter gameRestarter)
        {
            _levelGenerator = levelGenerator;
            _winCondition = winCondition;
            _gameRestarter = gameRestarter;

            _levelGenerator.LevelSpawned += OnLevelSpawned;
        }

        public void Disable()
        {
            _levelGenerator.LevelSpawned -= OnLevelSpawned;
        }

        private void OnLevelSpawned(Cell[] cells)
        {
            DisableButtons();

            _activeCells = cells;

            _winIdentificator = _winCondition.RegisterNewCondition(cells);
            _winConditionText.text = $"{FindConditionText} {_winIdentificator}";

            foreach (Cell cell in cells)
            {
                cell.Clicked += OnCellClick;
            }
        }

        private void DisableButtons()
        {
            if (_activeCells == null)
                return;

            foreach (Cell cell in _activeCells)
            {
                cell.Clicked -= OnCellClick;
            }
        }

        private void OnCellClick(Cell cell)
        {
            if (cell.Identificator == _winIdentificator)
            {
                StartCoroutine(HandleSuccessfullClick());
            }
            else
            {
            }
        }

        private IEnumerator HandleSuccessfullClick()
        {
            _blackPanel.gameObject.SetActive(true);

            yield return _waitForSeconds;

            if (_levelGenerator.HasLevels == true)
            {
                _nextLevelButton.gameObject.SetActive(true);
            }
            else
            {
                _restartGameButton.gameObject.SetActive(true);
            }
        }

        private void OnNextButtonClick()
        {
            _nextLevelButton.gameObject.SetActive(false);
            _blackPanel.gameObject.SetActive(false);

            _levelGenerator.SpawnNextLevel();
        }

        private void OnRestartButtonClick()
        {
            _restartGameButton.gameObject.SetActive(false);
            _blackPanel.gameObject.SetActive(false);

            _gameRestarter.Restart();
        }
    }
}