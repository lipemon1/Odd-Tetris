using System;
using OddTetris.Players;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceHolderBehavior : MonoBehaviour
    {
        [SerializeField] private PieceBehavior m_PieceBehavior;
        [SerializeField] private float m_AngleAmount;
        [SerializeField] private Rigidbody2D m_Rigidbody2D;

        private bool m_CollisionAlreadyStopped = false;
        [SerializeField] private PieceDownMovementBehavior m_DownMovementBehavior;
        [SerializeField] private PieceHorizontalMovement m_HorizontalMovementBehavior;
        [SerializeField] private AIHorizontalMovement m_AIHorizontalMovement;

        private void Start()
        {
            m_AngleAmount = GameSettings.Instance.AngleRotateAmount;
        }

        public void Rotate()
        {
            m_PieceBehavior.transform.RotateAround(m_PieceBehavior.transform.position, Vector3.forward, m_AngleAmount);
        }

        public void SetupPiece(PieceBehavior newPiece)
        {
            m_PieceBehavior = newPiece;
            
            m_PieceBehavior.transform.SetParent(this.transform);
            m_PieceBehavior.transform.localPosition = Vector3.zero;

            m_PieceBehavior.SetHolder(this);
            m_AIHorizontalMovement.SetHolder(this);
            newPiece.AddCollideEvent(OnCollideWithOtherPiece);
        }

        private void OnCollideWithOtherPiece()
        {
            if (!m_CollisionAlreadyStopped)
            {
                m_CollisionAlreadyStopped = true;
                m_DownMovementBehavior.StopMovingDown();
                DisableAIMovement();
                m_Rigidbody2D.gravityScale = 1;
            }
        }

        public void StartMovingDown(Action onPieceGrounded)
        {
            m_PieceBehavior.AddCollideEvent(onPieceGrounded);
            m_DownMovementBehavior.StartMovingDown();
        }

        public void MoveLeft()
        {
            m_HorizontalMovementBehavior.MoveLeft();
        }

        public void MoveRight()
        {
            m_HorizontalMovementBehavior.MoveRight();
        }

        public void SetPlayerOnPiece(Player player)
        {
            m_PieceBehavior.SetPlayer(player);
            m_HorizontalMovementBehavior.enabled = player.PlayerType == PlayerType.Human;
        }

        public void EnableAIMovement()
        {
            m_AIHorizontalMovement.enabled = true;
        }

        public void DisableAIMovement()
        {
            m_AIHorizontalMovement.enabled = false;
        }
    }   
}
