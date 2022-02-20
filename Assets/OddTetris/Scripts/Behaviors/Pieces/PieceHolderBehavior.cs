using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceHolderBehavior : MonoBehaviour
    {
        [SerializeField] private Transform m_PieceObject;
        [SerializeField] private float m_AngleAmount;
        [SerializeField] private Rigidbody2D m_Rigidbody2D;

        private bool m_CollidAlreadyStopped = false;
        [SerializeField] private PieceDownMovementBehavior m_DownMovementBehavior;

        [ContextMenu("Rotate")]
        public void Rotate()
        {
            m_PieceObject.RotateAround(m_PieceObject.position, Vector3.forward, m_AngleAmount);
        }

        public void SetupPiece(PieceBehavior newPiece)
        {
            m_PieceObject = newPiece.transform;
            
            m_PieceObject.SetParent(this.transform);
            m_PieceObject.localPosition = Vector3.zero;

            newPiece.SetCollideEvent(OnCollideWithOtherPiece);
        }

        private void OnCollideWithOtherPiece()
        {
            if (!m_CollidAlreadyStopped)
            {
                m_CollidAlreadyStopped = true;
                m_DownMovementBehavior.StopMovingDown();
                m_Rigidbody2D.gravityScale = 1;
            }
        }

        public void StartMovingDown()
        {
            m_DownMovementBehavior.StartMovingDown();
        }
    }   
}
