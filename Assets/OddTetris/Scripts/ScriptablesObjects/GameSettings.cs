using UnityEngine;

namespace OddTetris.Scriptables
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptables/Game Settings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public int PiecesPoolSize;
        public GameObject PiecePrefab;
    }   
}
