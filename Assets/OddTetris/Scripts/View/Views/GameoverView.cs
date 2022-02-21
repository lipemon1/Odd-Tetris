using System;
using System.Collections;
using System.Collections.Generic;
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
            GameLoopController.Instance.OpenMainMenu();
        }

        protected override void OnViewOpened()
        {
            base.OnViewOpened();
            Time.timeScale = 0f;
        }
    }   
}
