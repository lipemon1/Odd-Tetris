using System;
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
            Debug.Log("Rotate");
        }

        private void OnMoveRightClicked()
        {
            Debug.Log("Move Right");
        }

        private void OnMoveLeftClicked()
        {
            Debug.Log("Move Left");
        }
    }   
}