using UnityEngine;

namespace Models
{
    public class GameplayModel:Singleton<GameplayModel>
    {
        public enum GameStates
        {
            MainMenu,
            Init,
            Countdown,
            Gameplay,
            GameEnded
        }

        public GameStates GameState { get; set; } = GameStates.MainMenu;

        public int Score { get; set; }

        public int Lives { get; set; }

        public int CurrWave { get; set; }
        public int CountdownTime{ get; set; }
        public bool IsUfoAlive { get; set; }
        public int NumberOfEnemies { get; set; }
    }
}