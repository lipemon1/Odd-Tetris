using OddTetris.Behavior.Pieces;
using OddTetris.Players;

namespace OddTetris.GameLoop
{
    public class PlayerInputController : SingletonMonoBehavior<PlayerInputController>
    {
        private PieceHolderBehavior m_CurrentPieceBehavior;

        public void SetCurrentBehavior(PieceHolderBehavior pieceHolderBehavior, Player player)
        {
            if(player.PlayerType == PlayerType.Human)
                m_CurrentPieceBehavior = pieceHolderBehavior;
        }
        
        public void MoveLeft()
        {
            m_CurrentPieceBehavior.MoveLeft();
        }

        public void MoveRight()
        {
            m_CurrentPieceBehavior.MoveRight();
        }

        public void RotatePiece()
        {
            m_CurrentPieceBehavior.Rotate();
        }
    }   
}