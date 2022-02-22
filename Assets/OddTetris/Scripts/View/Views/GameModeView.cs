using OddTetris.Audio;
using OddTetris.GameLoop;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class GameModeView : ViewBehavior
    {
        [SerializeField] private Button m_SingleMode;
        [SerializeField] private Button m_VersusMode;

        #region Monobehavior

        private void Start()
        {
            m_SingleMode.onClick.AddListener(OnSingleModeSelected);
            m_VersusMode.onClick.AddListener(OnVersusModeSelected);
        }

        #endregion

        private void OnVersusModeSelected()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            GameLoopController.Instance.StartVersusGame();
        }

        private void OnSingleModeSelected()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            GameLoopController.Instance.StartSingleGame();
        }
    }   
}
