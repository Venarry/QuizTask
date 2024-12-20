using UnityEngine;

namespace Assets.Source.Scripts.Level
{
    public class WinConditionView : MonoBehaviour
    {
        private const string FindConditionText = "Find";

        [SerializeField] private FadeText _winConditionText;

        private IWinCondition _winCondition;
        private bool _isFirstFade = true;

        public void Init(IWinCondition winCondition)
        {
            _winCondition = winCondition;

            _winCondition.Installed += OnWinConditionSet;
        }

        public void ResetFadeState()
        {
            _isFirstFade = true;
        }

        public void Disable()
        {
            _winCondition.Installed -= OnWinConditionSet;
        }

        private void OnWinConditionSet(string identificator)
        {
            if (_isFirstFade == true)
            {
                _winConditionText.Show();
                _winConditionText.Turn();

                _isFirstFade = false;
            }

            _winConditionText.SetText(identificator);
            _winConditionText.SetText($"{FindConditionText} {identificator}");
        }
    }
}