using OddTetris.Audio;
using OddTetris.GameLoop;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class GameoverView : ViewBehavior
    {
        [SerializeField] private Button m_MainMenuButton;

        private void Start()
        {
            m_MainMenuButton.onClick.AddListener(MainMenuClicked);
        }

        private void MainMenuClicked()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            GameLoopController.Instance.OpenMainMenu();
        }

        protected override void OnViewOpened()
        {
            base.OnViewOpened();
            Time.timeScale = 0f;
        }
    }   
}
