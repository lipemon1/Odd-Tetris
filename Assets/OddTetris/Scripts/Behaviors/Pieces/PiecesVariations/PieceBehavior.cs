using System;
using OddTetris.Players;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public abstract class PieceBehavior : MonoBehaviour
    {
        private Action m_OnCollide;
        private Player m_Player;
        private PieceHolderBehavior m_PieceHolderBehavior;
        private bool m_IsDead;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            m_OnCollide?.Invoke();
            m_OnCollide = null;
            
            if (other.gameObject.CompareTag("PieceKiller") && !m_IsDead)
            {
                m_IsDead = true;
                PiecesKillerController.Instance.KillPieceByPlayer(m_PieceHolderBehavior, m_Player);
            }
        }

        public void AddCollideEvent(Action onCollideWithOtherPiece)
        {
            m_OnCollide += onCollideWithOtherPiece;
        }

        public void SetHolder(PieceHolderBehavior pieceHolder)
        {
            m_PieceHolderBehavior = pieceHolder;
        }

        public void SetPlayer(Player player)
        {
            m_Player = player;
        }
    }   
}
