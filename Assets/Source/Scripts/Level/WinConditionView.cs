using Assets.Source.Scripts.Level;
using TMPro;
using UnityEngine;

public class WinConditionView : MonoBehaviour
{
    private const string FindConditionText = "Find";

    [SerializeField] private TMP_Text _winConditionText;
    private IWinCondition _winCondition;

    public void Init(IWinCondition winCondition)
    {
        _winCondition = winCondition;

        _winCondition.Installed += OnWinConditionSet;
    }

    public void Disable()
    {
        _winCondition.Installed -= OnWinConditionSet;
    }

    private void OnWinConditionSet(string identificator)
    {
        _winConditionText.text = identificator;
        _winConditionText.text = $"{FindConditionText} {identificator}";
    }
}
