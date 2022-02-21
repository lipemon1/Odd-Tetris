using System;
using System.Collections.Generic;
using OddTetris.Players;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PiecesKillerController : SingletonMonoBehavior<PiecesKillerController>
    {
        private Dictionary<Player, List<PieceHolderBehavior>> m_PiecesKilled = new Dictionary<Player, List<PieceHolderBehavior>>();

        public delegate void OnPieceKilledDelegate(int newValue);
        public OnPieceKilledDelegate OnPiecePlayerKilled;
        public OnPieceKilledDelegate OnPieceAIKilled;

        public delegate void OnPlayerLostDelegate(Player playerLost);
        public OnPlayerLostDelegate OnPlayerLost;

        private int m_PieceAmountValue;
        private int m_PieceAmounts;

        private void OnEnable()
        {
            m_PieceAmountValue = GameSettings.Instance.PieceValue;
            m_PieceAmounts = GameSettings.Instance.PieceStartValue;
        }

        public void KillPieceByPlayer(PieceHolderBehavior pieceToKill, Player player)
        {
            int newValue = m_PieceAmounts;
            
            if (m_PiecesKilled.TryGetValue(player, out List<PieceHolderBehavior> piecesKilled))
            {
                piecesKilled.Add(pieceToKill);
                newValue -= piecesKilled.Count * m_PieceAmountValue;
            }
            else
            {
                m_PiecesKilled.Add(player, new List<PieceHolderBehavior>(){pieceToKill});
                newValue -= 1 * m_PieceAmountValue;
            }

            switch (player.PlayerType)
            {
                case PlayerType.Human:
                    OnPiecePlayerKilled?.Invoke(newValue);
                    break;
                case PlayerType.AI:
                    OnPieceAIKilled?.Invoke(newValue);
                    break;
                default:
                    Debug.LogException(new ArgumentOutOfRangeException());
                    break;
            }
            
            TryFinishMatch(newValue, player);
        }

        private void TryFinishMatch(int newValue, Player player)
        {
            if (newValue <= 0)
            {
                OnPlayerLost?.Invoke(player);
            }
        }

        public void ReceivePieceChild(PieceHolderBehavior piece)
        {
            piece.transform.SetParent(this.transform);
        }
    }
}