using System;
using OddTetris.Audio;
using OddTetris.GameLoop;
using UnityEngine;
using UnityEngine.UI;

namespace OddTetris.View
{
    public class InputView : ViewBehavior
    {
        [SerializeField] private Button m_MoveLeftButton;
        [SerializeField] private Button m_MoveRightButton;
        [SerializeField] private Button m_MoveRotateButton;

        private void Start()
        {
            m_MoveLeftButton.onClick.AddListener(OnMoveLeftClicked);
            m_MoveRightButton.onClick.AddListener(OnMoveRightClicked);
            m_MoveRotateButton.onClick.AddListener(OnRotateClicked);
        }

        private void OnRotateClicked()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Clicked);
            PlayerInputController.Instance.RotatePiece();
        }

        private void OnMoveRightClicked()
        {
            PlayerInputController.Instance.MoveRight();
        }

        private void OnMoveLeftClicked()
        {
            PlayerInputController.Instance.MoveLeft();
        }
    }   
}