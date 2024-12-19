using Assets.Source.Scripts.Cells;
using Assets.Source.Scripts.Level;
using Assets.Source.Scripts.SO;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWinHandler : MonoBehaviour
{
    private const float NextButtonShowDelay = 2f;

    [SerializeField] private Image _blackPanel;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private TMP_Text _winConditionText;

    private LevelGenerator _levelGenerator;
    private IWinCondition _winCondition;
    private string _winIdentificator;
    private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(NextButtonShowDelay);
    private Cell[] _activeCells;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnNextButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextButtonClick);
    }

    public void Init(LevelGenerator levelGenerator, IWinCondition winCondition)
    {
        _levelGenerator = levelGenerator;
        _winCondition = winCondition;

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
        _winConditionText.text = _winIdentificator;

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
        if(cell.Identificator == _winIdentificator)
        {
            StartCoroutine(ShowNextLevelButton());
        }
        else
        {
        }
    }

    private IEnumerator ShowNextLevelButton()
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
        _levelGenerator.SpawnNextLevel();
    }
}
