using System.Collections;
using System.Collections.Generic;
using OddTetris.GameLoop;
using UnityEngine;

namespace OddTetris.Players
{
    public enum PlayerType
    {
        Human,
        AI
    }
    
    [System.Serializable]
    public class Player
    {
        [SerializeField]
        private PlayerType m_PlayerType;

        public Player(PlayerType playerType, Transform singlePlayerTransform)
        {
            m_PlayerType = playerType;
            PiecesFallerController.Instance.StartNewFaller(singlePlayerTransform.position);
        }
    }   
}
