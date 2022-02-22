using System.Collections.Generic;
using OddTetris.Audio;
using OddTetris.Behavior;
using OddTetris.Behavior.Pieces;
using OddTetris.Players;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class PiecesFallerController : SingletonMonoBehavior<PiecesFallerController>
    {
        private List<PiecesFallerBehavior> m_Fallers = new List<PiecesFallerBehavior>();
        private List<PieceHolderBehavior> m_PiecesFalling = new List<PieceHolderBehavior>();
        private Transform m_fallersHolder;

        private void Start()
        {
            PiecesKillerController.Instance.OnPlayerLost += OnPlayerLost;
        }

        public void StartNewFaller(Vector3 position, Player player)
        {
            if (m_fallersHolder == null)
                m_fallersHolder = CreateFallerHolder();

            PiecesFallerBehavior fallerBehavior = GetNewFallerBehaviorObject(m_fallersHolder);
            fallerBehavior.StartFallingPieces(position, () => CallNewPieceToFall(fallerBehavior), player);
            m_Fallers.Add(fallerBehavior);
        }

        private void CallNewPieceToFall(PiecesFallerBehavior faller)
        {
            SFXController.Instance.PlaySfx(AudioIdentifier.Grounded);
            faller.FallPiece(() => CallNewPieceToFall(faller));
        }

        private Transform CreateFallerHolder()
        {
            GameObject newHolder = new GameObject("Faller Holder");
            newHolder.transform.SetParent(this.transform);
            return newHolder.transform;
        }

        private PiecesFallerBehavior GetNewFallerBehaviorObject(Transform fallerHolder)
        {
            GameObject newHolder = new GameObject("Faller Behavior");
            newHolder.transform.SetParent(fallerHolder);
            return newHolder.AddComponent<PiecesFallerBehavior>();
        }

        public void RegisterFallingPiece(PieceHolderBehavior pieceHolderBehavior)
        {
            m_PiecesFalling.Add(pieceHolderBehavior);
        }

        private void OnPlayerLost(Player playerlost)
        {
            foreach (PiecesFallerBehavior fallerBehavior in m_Fallers)
            {
                Destroy(fallerBehavior.gameObject);
            }

            foreach (PieceHolderBehavior pieceHolderBehavior in m_PiecesFalling)
            {
                if(pieceHolderBehavior == null)
                    continue;
                
                Destroy(pieceHolderBehavior.gameObject); //Change to Despawn
            }
            
            m_Fallers.Clear();
            m_PiecesFalling.Clear();
        }
    }
}