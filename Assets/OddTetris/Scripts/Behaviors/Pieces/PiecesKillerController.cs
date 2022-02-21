using System.Collections.Generic;
using OddTetris.Players;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PiecesKillerController : SingletonMonoBehavior<PiecesKillerController>
    {
        private Dictionary<Player, List<PieceHolderBehavior>> m_PiecesKilled = new Dictionary<Player, List<PieceHolderBehavior>>();

        public void KillPieceByPlayer(PieceHolderBehavior pieceToKill, Player player)
        {
            if (m_PiecesKilled.TryGetValue(player, out List<PieceHolderBehavior> piecesKilled))
            {
                piecesKilled.Add(pieceToKill);
                
                Debug.Log($"Player {player} has {piecesKilled.Count} killed pieces");
            }
            else
            {
                m_PiecesKilled.Add(player, new List<PieceHolderBehavior>(){pieceToKill});
                Debug.Log($"Player {player} has 1 killed pieces");
            }
        }
    }   
}
