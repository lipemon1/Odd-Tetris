using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class HUDView : ViewBehavior
    {
        [SerializeField] private Slider m_PlayerLifeBar;
        [SerializeField] private Slider m_AILifeBar;

        public void ShowPlayerLifeBar()
        {
            m_PlayerLifeBar.gameObject.SetActive(true);
        }

        public void ShowAILifeBar()
        {
            m_AILifeBar.gameObject.SetActive(true);
        }

        public void HideLifebars()
        {
            m_PlayerLifeBar.gameObject.SetActive(false);
            m_AILifeBar.gameObject.SetActive(false);
        }

        public override void OnSinglePlayerStart()
        {
            base.OnSinglePlayerStart();
            HideLifebars();
            ShowPlayerLifeBar();
        }

        public override void OnVersusAIStart()
        {
            base.OnVersusAIStart();
            HideLifebars();
            ShowPlayerLifeBar();
            ShowAILifeBar();
        }
    }   
}
