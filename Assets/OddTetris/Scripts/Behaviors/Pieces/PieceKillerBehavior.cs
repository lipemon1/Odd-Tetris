using System;
using UnityEngine;

namespace OddTetris.Behavior.Pieces
{
    public class PieceKillerBehavior : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"Kill piece {other.gameObject.name}");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log($"Piece {other.gameObject.name} collide kill");
        }
    }
}
