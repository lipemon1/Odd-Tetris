using System;
using OddTetris.Scriptables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OddTetris.Behavior.Pieces
{
    public enum MoveType
    {
        Rotate,
        MoveLeft,
        MoveRight
    }
    
    public class AIHorizontalMovement : MonoBehaviour
    {
        private float m_CurrentTime;
        private double m_TimeToDecision;
        private PieceHolderBehavior m_PieceHolderBehavior;
        private float m_MovementAmount;

        private void Awake()
        {
            this.enabled = false;
        }

        private void Start()
        {
            m_TimeToDecision = GameSettings.Instance.AIDecisionTime;
            m_MovementAmount = GameSettings.Instance.HorizontalMovementAmount;
        }

        private void Update()
        {
            m_CurrentTime += Time.deltaTime;
            
            if (m_CurrentTime > m_TimeToDecision)
            {
                m_CurrentTime = 0;

                MakeNewMove();
            }
        }

        private void MakeNewMove()
        {
            MoveType newDecision = (MoveType)Random.Range(0, 3);

            switch (newDecision)
            {
                case MoveType.Rotate:
                    m_PieceHolderBehavior.Rotate();
                    break;
                case MoveType.MoveLeft:
                    MoveLeft();
                    break;
                case MoveType.MoveRight:
                    MoveRight();
                    break;
                default:
                    Debug.LogException(new ArgumentOutOfRangeException());
                    break;
            }
        }

        private void MoveRight()
        {
            transform.Translate(Vector3.right * m_MovementAmount);
        }

        private void MoveLeft()
        {
            transform.Translate(Vector3.left * m_MovementAmount);
        }

        public void SetHolder(PieceHolderBehavior pieceHolderBehavior)
        {
            m_PieceHolderBehavior = pieceHolderBehavior;
        }
    }   
}
