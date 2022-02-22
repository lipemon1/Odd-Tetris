using OddTetris.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class GameplayView : ViewBehavior
    {
        [SerializeField] private Button m_PauseButton;

        private void Start()
        {
            m_PauseButton.onClick.AddListener(OnPauseClicked);
        }

        private void OnPauseClicked()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            ViewController.OpenView(ViewType.Pause);
        }
    }   
}
