using Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        private void Start()
        {
            HighScoreModel.Instance.InitHighScores();
        }

        public void StartGameplay()
        {
            SceneManager.LoadScene("Game");
            GameplayModel.Instance.GameState = GameplayModel.GameStates.Init;
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
