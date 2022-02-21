using System;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceHorizontalMovement : MonoBehaviour
    {
        private float m_MovementAmount;

        private void Start()
        {
            m_MovementAmount = GameSettings.Instance.HorizontalMovementAmount;
        }

        public void MoveRight()
        {
            transform.Translate(Vector3.right * m_MovementAmount);
        }

        public void MoveLeft()
        {
            transform.Translate(Vector3.left * m_MovementAmount);
        }
    }
}