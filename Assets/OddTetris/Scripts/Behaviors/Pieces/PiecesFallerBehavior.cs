using System;
using OddTetris.Behavior.Pieces;
using OddTetris.GameLoop;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior
{
    public class PiecesFallerBehavior : MonoBehaviour
    {
        private Vector3 m_FallPosition;

        public void FallPiece(Action onPieceGrounded)
        {
            PieceHolderBehavior piece = PiecesPoolController.Instance.GetRandomPiece();
            piece.transform.position = m_FallPosition;
            piece.StartMovingDown(onPieceGrounded);
        }

        public void StartFallingPieces(Vector3 positionToStartFalling, Action onPieceGrounded)
        {
            m_FallPosition = positionToStartFalling;
            
            FallPiece(onPieceGrounded);
        }
    }   
}
