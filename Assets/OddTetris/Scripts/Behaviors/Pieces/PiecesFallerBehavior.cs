using System;
using OddTetris.Behavior.Pieces;
using OddTetris.GameLoop;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior
{
    public class PiecesFallerBehavior : MonoBehaviour
    {
        private bool m_IsFallingPieces = false;
        private float m_DelayBetweenPieces;
        private float m_CurrentTime;
        private Vector3 m_FallPosition;

        private void Update()
        {
            if (m_IsFallingPieces)
            {
                if(m_CurrentTime > m_DelayBetweenPieces)
                    FallPiece();

                m_CurrentTime += Time.deltaTime;
            }
        }

        private void FallPiece()
        {
            m_CurrentTime = 0f;

            PieceHolderBehavior piece = PiecesPoolController.Instance.GetRandomPiece();
            piece.transform.position = m_FallPosition;
            piece.StartMovingDown();
        }

        public void StartFallingPieces(Vector3 positionToStartFalling)
        {
            m_FallPosition = positionToStartFalling;
            m_DelayBetweenPieces = GameSettings.Instance.TimeBetweenPieces;
            m_IsFallingPieces = true;
        }

        public void StopFallingPieces()
        {
            m_IsFallingPieces = false;
        }
    }   
}
