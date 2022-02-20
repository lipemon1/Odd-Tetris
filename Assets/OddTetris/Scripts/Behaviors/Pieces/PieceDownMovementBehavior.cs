using System;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceDownMovementBehavior : MonoBehaviour
    {
        private bool m_IsMovingDown;
        private float m_NextMoveTime;
        private float m_Amount;
        private float m_CurrentMovementTime;
        
        private void Update()
        {
            if (!m_IsMovingDown)
                return;
            
            if (m_CurrentMovementTime > m_NextMoveTime)
            {
                MoveDown();
                m_CurrentMovementTime = 0f;
            }

            m_CurrentMovementTime += Time.deltaTime;
        }

        private void MoveDown()
        {
            transform.Translate(Vector3.down * m_Amount * Time.deltaTime);
        }

        public void StartMovingDown()
        {
            m_NextMoveTime = GameSettings.Instance.DownMovementFrequency;
            m_Amount = GameSettings.Instance.DownMovementAmount;
            
            m_IsMovingDown = true;
        }

        public void StopMovingDown()
        {
            m_IsMovingDown = false;
        }
    }
   
}