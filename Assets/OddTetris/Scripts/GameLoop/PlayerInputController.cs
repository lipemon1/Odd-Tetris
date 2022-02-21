using OddTetris.Behavior.Pieces;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class PlayerInputController : SingletonMonoBehavior<PlayerInputController>
    {
        private PieceHolderBehavior m_CurrentPieceBehavior;

        public void SetCurrentBehavior(PieceHolderBehavior pieceHolderBehavior)
        {
            m_CurrentPieceBehavior = pieceHolderBehavior;
        }
        
        public void MoveLeft()
        {
            
        }

        public void MoveRight()
        {
            
        }

        public void RotatePiece()
        {
            m_CurrentPieceBehavior.Rotate();
        }
    }   
}
