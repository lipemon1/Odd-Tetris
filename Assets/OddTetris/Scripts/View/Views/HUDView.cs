using System;
using OddTetris.Behavior.Pieces;
using OddTetris.Scriptables;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class HUDView : ViewBehavior
    {
        [SerializeField] private Slider m_PlayerLifeBar;
        [SerializeField] private Slider m_AILifeBar;

        private void Start()
        {
            int initialValue = GameSettings.Instance.PieceStartValue;
            m_PlayerLifeBar.maxValue = initialValue;
            m_PlayerLifeBar.value = initialValue;
            m_AILifeBar.maxValue = initialValue;
            m_AILifeBar.value = initialValue;
            
            PiecesKillerController.Instance.OnPiecePlayerKilled += OnPiecePlayerKilled;
            PiecesKillerController.Instance.OnPieceAIKilled += OnPieceAIKilled;
        }

        private void OnPieceAIKilled(int newValue)
        {
            m_PlayerLifeBar.value = newValue;
        }

        private void OnPiecePlayerKilled(int newValue)
        {
            m_PlayerLifeBar.value = newValue;
        }

        private void ShowPlayerLifeBar()
        {
            m_PlayerLifeBar.gameObject.SetActive(true);
        }

        private void ShowAILifeBar()
        {
            m_AILifeBar.gameObject.SetActive(true);
        }

        private void HideLifeBars()
        {
            m_PlayerLifeBar.gameObject.SetActive(false);
            m_AILifeBar.gameObject.SetActive(false);
        }

        public override void OnSinglePlayerStart()
        {
            base.OnSinglePlayerStart();
            HideLifeBars();
            ShowPlayerLifeBar();
        }

        public override void OnVersusAIStart()
        {
            base.OnVersusAIStart();
            HideLifeBars();
            ShowPlayerLifeBar();
            ShowAILifeBar();
        }
    }   
}
