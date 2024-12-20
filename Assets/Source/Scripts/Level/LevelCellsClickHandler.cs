using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Effects;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Scripts.Level
{
    public class LevelCellsClickHandler : MonoBehaviour
    {
        private const float NextButtonShowDelay = 2f;

        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _restartGameButton;
        [SerializeField] private FadeImage _blackPanel;
        [SerializeField] private ParticleSystem _starsFirework;

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

        private void OnCellClick(Cell cell, Vector3 clickPosition)
        {
            if (cell.Identificator == _winIdentificator)
            {
                Instantiate(_starsFirework, clickPosition, Quaternion.identity);
                cell.StartSymbolBounceEffect();

                StartCoroutine(HandleSuccessfulClick());
            }
            else
            {
                cell.StartSymbolEaseInBounce();
            }
        }

        private IEnumerator HandleSuccessfulClick()
        {
            _blackPanel.Show();

            yield return _waitForSeconds;

            Task task = _blackPanel.Turn();
            
            while (task.IsCompleted == false)
            {
                yield return null;
            }

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
            _blackPanel.Hide();

            _levelGenerator.SpawnNextLevel(startBounceEffect: false);
        }

        private async void OnRestartButtonClick()
        {
            _restartGameButton.gameObject.SetActive(false);

            await _gameRestarter.Restart();

            _blackPanel.Hide();
        }
    }
}