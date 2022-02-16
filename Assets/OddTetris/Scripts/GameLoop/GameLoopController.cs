using OddTetris.Scriptables;
using OddTetris.View;
using UnityEngine;

namespace OddTetris.GameLoop
{
    public class GameLoopController : SingletonMonoBehavior<GameLoopController>
    {
        [SerializeField] private GameSettings m_GameSettings;

        public void StartSingleGame()
        {
            PiecesSpawnController.Instance.StartPiecesPool(m_GameSettings.PiecesPoolSize, m_GameSettings.PiecePrefab, m_GameSettings.Pieces, OnPoolReady);
            ViewController.CloseView(ViewType.GameMode);
            ViewController.CloseView(ViewType.Menu);
        }

        public void StartVersusGame()
        {
            
        }
        
        private void OnPoolReady()
        {
            throw new System.NotImplementedException();
        }
    }   
}
