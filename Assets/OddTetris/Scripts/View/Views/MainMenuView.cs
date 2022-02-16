using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class MainMenuView : ViewBehavior
    {
        [SerializeField] private Button m_PlayButton;

        private void Start()
        {
            m_PlayButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnPlayClicked()
        {
            m_PlayButton.interactable = false;
            ViewController.OpenView(ViewType.GameMode, false);
        }
    }   
}
