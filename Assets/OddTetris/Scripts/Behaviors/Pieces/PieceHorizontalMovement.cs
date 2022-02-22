using OddTetris.Audio;
using OddTetris.Scriptables;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceHorizontalMovement : MonoBehaviour
    {
        private float m_MovementAmount;

        private void Start()
        {
            m_MovementAmount = GameSettings.Instance.HorizontalMovementAmount;
        }

        public void MoveRight()
        {
            PlaySfx();
            transform.Translate(Vector3.right * m_MovementAmount);
        }

        public void MoveLeft()
        {
            PlaySfx();
            transform.Translate(Vector3.left * m_MovementAmount);
        }

        private void PlaySfx()
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Movement);
        }
    }
}