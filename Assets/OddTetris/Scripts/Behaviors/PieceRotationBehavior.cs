using UnityEngine;

namespace OddTetris.Behavior
{
    public class PieceRotationBehavior : MonoBehaviour
    {
        [SerializeField] private Transform m_PieceObject;
        [SerializeField] private float m_AngleAmount;

        [ContextMenu("Rotate")]
        public void Rotate()
        {
            m_PieceObject.RotateAround(m_PieceObject.position, Vector3.forward, m_AngleAmount);
        }
    }   
}
