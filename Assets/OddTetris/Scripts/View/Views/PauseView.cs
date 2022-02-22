using OddTetris.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class PauseView : ViewBehavior
    {
        [SerializeField] private Button m_UnPauseButton;

        private void Start()
        {
            m_UnPauseButton.onClick.AddListener(OnUnPauseClicked);
        }

        private void OnUnPauseClicked()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            ViewController.CloseView(ViewType.Pause);
        }

        protected override void OnViewOpened()
        {
            base.OnViewOpened();
            Time.timeScale = 0f;
        }

        protected override void OnViewClosed()
        {
            base.OnViewClosed();
            Time.timeScale = 1f;
        }
    }   
}
