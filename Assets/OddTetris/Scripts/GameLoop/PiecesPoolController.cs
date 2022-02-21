using System;
using System.Collections;
using System.Collections.Generic;
using OddTetris.Behavior.Pieces;
using OddTetris.Scriptables;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace OddTetris.GameLoop
{
    public class PiecesPoolController : SingletonMonoBehavior<PiecesPoolController>
    {
        private List<PieceHolderBehavior> m_PiecesHolderPool = new List<PieceHolderBehavior>();
        private Dictionary<Type, List<PieceBehavior>> m_PiecesPool = new Dictionary<Type, List<PieceBehavior>>();
        private List<Type> m_typesOnPool = new List<Type>();
        private Dictionary<Type, PieceBehavior> m_PrefabsByType = new Dictionary<Type, PieceBehavior>();
        private static Vector3 _PoolPosition = new Vector3(-9999f, -9999f, -9999f);

        private bool m_IsCreatingPieces;
        public bool IsCreatingPieces => m_IsCreatingPieces;
        private bool m_IsPoolFinished;
        public bool IsPoolFinished => m_IsPoolFinished;
        
        public void StartPiecesPool(Action onPoolReady)
        {
            StartCoroutine(PoolCreationCo(onPoolReady));
        }

        private IEnumerator PoolCreationCo(Action onPoolReady)
        {
            m_IsCreatingPieces = true;
            m_IsPoolFinished = false;
            
            int amountCreated = 0;
         
            GameSettings gameSettings = GameSettings.Instance;
            GameObject piecePoolHolder = new GameObject($"{gameSettings.PiecePrefab.name}");
            piecePoolHolder.transform.SetParent(this.transform);
            while (amountCreated < gameSettings.PiecesPoolSize)
            {
                PieceHolderBehavior newPieceHolder = InstantiatePoolItem(gameSettings.PiecePrefab);
                newPieceHolder.transform.SetParent(piecePoolHolder.transform);
                m_PiecesHolderPool.Add(newPieceHolder);
                amountCreated++;
                yield return null;
            }

            amountCreated = 0;
            m_typesOnPool.Clear();

            foreach (PieceBehavior piecePrefab in gameSettings.Pieces)
            {
                GameObject poolHolder = new GameObject($"{piecePrefab.name}");
                poolHolder.transform.SetParent(this.transform);
                
                while (amountCreated < gameSettings.PiecesPoolSize)
                {
                    PieceBehavior newPiece = InstantiatePoolItem(piecePrefab);
                    newPiece.transform.SetParent(poolHolder.transform);

                    Type pieceType = newPiece.GetType();

                    if (m_PiecesPool.TryGetValue(pieceType, out List<PieceBehavior> piecesFound))
                    {
                        piecesFound.Add(newPiece);
                    }
                    else
                    {
                        m_PiecesPool.Add(pieceType, new List<PieceBehavior>(){newPiece});
                        m_typesOnPool.Add(pieceType);
                        m_PrefabsByType.Add(pieceType, piecePrefab);
                    }
                    
                    amountCreated++;
                    yield return null;
                }

                amountCreated = 0;
            }

            m_IsCreatingPieces = false;
            m_IsPoolFinished = true;
            onPoolReady?.Invoke();
        }

        private T InstantiatePoolItem<T>(T prefab) where T : Object
        {
            return Instantiate<T>(prefab, _PoolPosition, Quaternion.identity);
        }

        private PieceHolderBehavior SpawnHolderPiece()
        {
            if (m_PiecesHolderPool.Count > 0)
            {
                PieceHolderBehavior holderPiece = m_PiecesHolderPool[0];
                m_PiecesHolderPool.RemoveAt(0);
                PiecesKillerController.Instance.ReceivePieceChild(holderPiece);
                return holderPiece;
            }
            else
            {
                return InstantiatePoolItem(GameSettings.Instance.PiecePrefab);
            }
        }

        private PieceBehavior SpawnPieceBehavior(Type pieceType)
        {
            if (m_PiecesPool.TryGetValue(pieceType, out List<PieceBehavior> pieceBehaviors))
            {
                if (pieceBehaviors.Count > 0)
                {
                    PieceBehavior piece = pieceBehaviors[0];
                    piece.transform.SetParent(null);
                    pieceBehaviors.RemoveAt(0);
                    return piece;
                }
                else
                {
                    return InstantiatePoolItem(GetPieceToInstantiateByType(pieceType));
                }
            }
            else
            {
                return InstantiatePoolItem(GetPieceToInstantiateByType(pieceType));
            }
        }

        private PieceBehavior GetPieceToInstantiateByType(Type pieceTypeWanted)
        {
            if (m_PrefabsByType.TryGetValue(pieceTypeWanted, out PieceBehavior piecePrefab))
            {
                return piecePrefab;
            }
            else
            {
                Debug.LogError($"No prefab found with type {pieceTypeWanted.Name}");
                return null;
            }
        }

        public PieceHolderBehavior GetRandomPiece()
        {
            int maxValue = m_typesOnPool.Count;
            int selectedValue = Random.Range(0, maxValue);

            PieceHolderBehavior pieceHolder = SpawnHolderPiece();
            pieceHolder.SetupPiece(SpawnPieceBehavior(m_typesOnPool[selectedValue]));
            return pieceHolder;
        }
    }   
}
