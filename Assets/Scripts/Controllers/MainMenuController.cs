using Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGameplay()
        {
            SceneManager.LoadScene("Game");
            GameplayModel.Instance.GameState = GameplayModel.GameStates.Init;
        }
    }
}
