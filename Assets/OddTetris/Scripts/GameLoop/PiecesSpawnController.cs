using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class PiecesSpawnController : SingletonMonoBehavior<PiecesSpawnController>
    {
        private HashSet<GameObject> m_PiecesPool = new HashSet<GameObject>();
        
        public void StartPiecesPool(int poolSize, GameObject piecePrefab, Action onPoolReady)
        {
            StartCoroutine(PoolCreationCo(poolSize, piecePrefab, onPoolReady));
        }

        private IEnumerator PoolCreationCo(int size, GameObject piecePrefab, Action onPoolReady)
        {
            while (m_PiecesPool.Count < size)
            {
                GameObject newPiece = Instantiate(piecePrefab, this.transform);
                m_PiecesPool.Add(newPiece);
                yield return null;
            }
            
            onPoolReady?.Invoke();
        }
    }   
}
