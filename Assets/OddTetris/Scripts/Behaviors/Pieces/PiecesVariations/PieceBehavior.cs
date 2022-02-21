using System;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public abstract class PieceBehavior : MonoBehaviour
    {
        private Action m_OnCollide;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            m_OnCollide?.Invoke();
            m_OnCollide = null;
        }

        public void AddCollideEvent(Action onCollideWithOtherPiece)
        {
            m_OnCollide += onCollideWithOtherPiece;
        }
    }   
}
