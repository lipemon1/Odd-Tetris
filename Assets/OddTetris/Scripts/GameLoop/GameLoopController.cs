using System.Collections.Generic;
using OddTetris.Behavior.Pieces;
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

        [Header("Bases")] 
        [SerializeField] private Transform m_HumanPlayerBase;
        [SerializeField] private Transform m_AIPlayerBase;

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
            m_Players.Add(GetNewHumanPlayer());
            
            SetBasesPositions(false, GameSettings.Instance.BaseHorizontalOffset);
            
            ViewController.OnSingleStart();

            OnAnyStart();
        }

        public void StartVersusGame()
        {
            m_Players.Add(GetNewHumanPlayer(true));
            m_Players.Add(GetAIPlayer());
            
            SetBasesPositions(true, GameSettings.Instance.BaseHorizontalOffset);
            
            ViewController.OnAIVersusStart();

            OnAnyStart();
        }

        private void OnAnyStart()
        {
            ViewController.CloseView(ViewType.GameMode);
            ViewController.CloseView(ViewType.Menu);
            
            ViewController.OpenView(ViewType.Gameplay);
            ViewController.OpenView(ViewType.HUD);
            ViewController.OpenView(ViewType.Input);
            Time.timeScale = 1f;
        }

        private void SetBasesPositions(bool hasEnemy, float baseOffset)
        {
            if(hasEnemy)
                m_HumanPlayerBase.position = new Vector3(m_VersusHumanPlayerTransform.position.x + baseOffset, m_HumanPlayerBase.position.y, m_HumanPlayerBase.position.z);
            else
                m_HumanPlayerBase.position = new Vector3(m_SinglePlayerTransform.position.x + baseOffset, m_HumanPlayerBase.position.y, m_HumanPlayerBase.position.z);
            
            m_AIPlayerBase.position = new Vector3(m_VersusAIPlayerTransform.position.x + baseOffset, m_HumanPlayerBase.position.y, m_HumanPlayerBase.position.z);
            m_AIPlayerBase.gameObject.SetActive(hasEnemy);
        }
        
        private Player GetNewHumanPlayer(bool hasEnemy = false)
        {
            if(hasEnemy)
                return new Player(PlayerType.Human, m_VersusHumanPlayerTransform);
            else
                return new Player(PlayerType.Human, m_SinglePlayerTransform);
        }

        private Player GetAIPlayer()
        {
            return new Player(PlayerType.AI, m_VersusAIPlayerTransform);
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
