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

        [Space] [Header("Pieces Movement")] 
        public float HorizontalMovementAmount;
        public float DownMovementAmount;
        public float DownMovementFrequency;
        public float AngleRotateAmount; 

        [Space] [Header("Pieces Values")] 
        public int PieceValue;
        public int PieceStartValue;
        
        [Space] [Header("Bases")]
        public float BaseHorizontalOffset;
        
        [Space] [Header("AI")]
        public float AIDecisionTime;

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
