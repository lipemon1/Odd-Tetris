using System;
using System.Collections.Generic;
using OddTetris.Players;
using OddTetris.Scriptables;
using OddTetris.View;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class GameLoopController : SingletonMonoBehavior<GameLoopController>
    {
        [SerializeField] private List<Player> m_Players = new List<Player>();
        
        [Header("Transforms for Faller")]
        [SerializeField] private Transform m_SinglePlayerTransform;
        [SerializeField] private Transform m_VersusHumanPlayerTransform;
        [SerializeField] private Transform m_VersusAIPlayerTransform;

        private void Awake()
        {
            PiecesPoolController.Instance.StartPiecesPool(OnPoolReady);
        }

        public void StartSingleGame()
        {
            m_Players.Clear();

            Player player = new Player(PlayerType.Human, m_SinglePlayerTransform);
            m_Players.Add(player);
            
            ViewController.OnSingleStart();

            ViewController.CloseView(ViewType.GameMode);
            ViewController.CloseView(ViewType.Menu);
            
            ViewController.OpenView(ViewType.Gameplay);
            ViewController.OpenView(ViewType.HUD);
        }

        public void StartVersusGame()
        {
            
        }

        private void KillPieceByPlayer()
        {
            
        }
        
        private void OnPoolReady()
        {
            Debug.Log("Pool has finished");
        }
    }   
}
