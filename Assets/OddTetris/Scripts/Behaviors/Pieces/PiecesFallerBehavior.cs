using System;
using OddTetris.Behavior.Pieces;
using OddTetris.GameLoop;
using OddTetris.Players;
using UnityEngine;

namespace OddTetris.Behavior
{
    public class PiecesFallerBehavior : MonoBehaviour
    {
        private Vector3 m_FallPosition;
        private Player m_Player;

        public void FallPiece(Action onPieceGrounded)
        {
            PieceHolderBehavior piece = PiecesPoolController.Instance.GetRandomPiece();
            PiecesFallerController.Instance.RegisterFallingPiece(piece);
            piece.transform.position = m_FallPosition;
            piece.StartMovingDown(onPieceGrounded);
            piece.SetPlayerOnPiece(m_Player);
            PlayerInputController.Instance.SetCurrentBehavior(piece, m_Player);
        }

        public void StartFallingPieces(Vector3 positionToStartFalling, Action onPieceGrounded, Player player)
        {
            m_Player = player;
            m_FallPosition = positionToStartFalling;
            
            FallPiece(onPieceGrounded);
        }
    }   
}
