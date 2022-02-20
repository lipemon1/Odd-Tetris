using OddTetris.Behavior;
using OddTetris.Behavior.Pieces;
using UnityEngine;

namespace OddTetris.Scriptables
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptables/Game Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        [Header("Pieces Pool")]
        public int PiecesPoolSize;
        public PieceHolderBehavior PiecePrefab;
        public PieceBehavior[] Pieces;
        
        [Space]
        [Header("Pieces Spawn")]
        public float TimeBetweenPieces;

        [Space] 
        [Header("Pieces Movement")] 
        public float DownMovementAmount;
        public float DownMovementFrequency;

        private static GameSettings m_Instance = null;
        public static GameSettings Instance => GetGameSettingsReference();

        private static GameSettings GetGameSettingsReference()
        {
            if (m_Instance == null)
                m_Instance = Resources.Load<GameSettings>("Game Settings");
            
            return m_Instance;
        }
    }   
}
