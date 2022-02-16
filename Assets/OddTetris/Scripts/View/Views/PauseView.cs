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
            ViewController.CloseView(ViewType.Pause);
        }
    }   
}
