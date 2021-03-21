public class GameplayModel:Singleton<GameplayModel>
{
    public bool IsUfoAlive = true;
    public enum GameStates
    {
        MainMenu,
        Init,
        Gameplay,
        GameEnded
    }

    public GameStates GameState { get; set; } = GameStates.MainMenu;

    public int Score { get; set; }

    public int Lives { get; set; }
    
    public int Wave { get; set; }
}