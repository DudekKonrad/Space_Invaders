using Utils;

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
        
        public enum Difficulties
        {
            Easy,
            Medium,
            Hard
        }

        public enum ShootingStyle
        {
            Single,
            Double,
        }

        public GameStates GameState { get; set; } = GameStates.MainMenu;

        public Difficulties Difficulty { get; set; } = Difficulties.Hard;

        public ShootingStyle Shooting { get; set; } = ShootingStyle.Single;

        public int Score { get; set; }

        public int Lives { get; set; }

        public int CurrWave { get; set; }
        public int CountdownTime{ get; set; }
        public bool IsUfoAlive { get; set; }
        public int NumberOfEnemies { get; set; }
    }
}