using System;
using System.Collections;
using System.Collections.Generic;
using OddTetris.Behavior;
using Unity.Mathematics;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class PiecesSpawnController : SingletonMonoBehavior<PiecesSpawnController>
    {
        private HashSet<GameObject> m_PiecesHolderPool = new HashSet<GameObject>();
        private HashSet<PieceBehavior> m_PiecesPool = new HashSet<PieceBehavior>();
        private static Vector3 _PoolPosition = new Vector3(-9999f, -9999f, -9999f);
        
        public void StartPiecesPool(int poolSize, GameObject piece, PieceBehavior[] pieces, Action onPoolReady)
        {
            StartCoroutine(PoolCreationCo(poolSize, piece, pieces, onPoolReady));
        }

        private IEnumerator PoolCreationCo(int size, GameObject piece, PieceBehavior[] pieces, Action onPoolReady)
        {
            int amountCreated = 0;
            
            GameObject piecePoolHolder = new GameObject($"{piece.name}");
            piecePoolHolder.transform.SetParent(this.transform);
            while (amountCreated < size)
            {
                GameObject newPiece = Instantiate(piece, _PoolPosition, quaternion.identity);
                newPiece.transform.SetParent(piecePoolHolder.transform);
                m_PiecesHolderPool.Add(newPiece);
                amountCreated++;
                yield return null;
            }

            amountCreated = 0;
            
            foreach (PieceBehavior piecePrefab in pieces)
            {
                GameObject poolHolder = new GameObject($"{piecePrefab.name}");
                poolHolder.transform.SetParent(this.transform);
                
                while (amountCreated < size)
                {
                    PieceBehavior newPiece = Instantiate(piecePrefab, _PoolPosition, quaternion.identity);
                    newPiece.transform.SetParent(poolHolder.transform);
                    m_PiecesPool.Add(newPiece);
                    amountCreated++;
                    yield return null;
                }

                amountCreated = 0;
            }

            onPoolReady?.Invoke();
        }
    }   
}
