using System;
using System.Collections.Generic;
using OddTetris.Behavior.Pieces;
using OddTetris.Players;
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

        private void Start()
        {
            PiecesKillerController.Instance.OnPlayerLost += OnPlayerLost;
        }

        public void StartSingleGame()
        {
            Player player = new Player(PlayerType.Human, m_SinglePlayerTransform);
            m_Players.Add(player);
            
            ViewController.OnSingleStart();

            ViewController.CloseView(ViewType.GameMode);
            ViewController.CloseView(ViewType.Menu);
            
            ViewController.OpenView(ViewType.Gameplay);
            ViewController.OpenView(ViewType.HUD);
            ViewController.OpenView(ViewType.Input);
            Time.timeScale = 1f;
        }

        public void StartVersusGame()
        {
            
        }
        
        private void OnPlayerLost(Player playerlost)
        {
            m_Players.Clear();
            ViewController.OpenView(ViewType.Gameover);
        }

        private void OnPoolReady()
        {
            Debug.Log("Pool has finished");
        }

        public void OpenMainMenu()
        {
            ViewController.OpenView(ViewType.GameMode);
            ViewController.OpenView(ViewType.Menu);
            
            ViewController.CloseView(ViewType.Gameplay);
            ViewController.CloseView(ViewType.HUD);
            ViewController.CloseView(ViewType.Input);
            ViewController.CloseView(ViewType.Gameover);
        }
    }   
}
