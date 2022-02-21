using System;
using System.Collections.Generic;
using OddTetris.Behavior;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class PiecesFallerController : SingletonMonoBehavior<PiecesFallerController>
    {
        private List<PiecesFallerBehavior> m_Fallers = new List<PiecesFallerBehavior>();
        private Transform m_fallersHolder;

        public void StartNewFaller(Vector3 position)
        {
            if (m_fallersHolder == null)
                m_fallersHolder = CreateFallerHolder();

            PiecesFallerBehavior fallerBehavior = GetNewFallerBehaviorObject(m_fallersHolder);
            fallerBehavior.StartFallingPieces(position, () => CallNewPieceToFall(fallerBehavior));
            m_Fallers.Add(fallerBehavior);
        }

        private void CallNewPieceToFall(PiecesFallerBehavior faller)
        {
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
    }
}
