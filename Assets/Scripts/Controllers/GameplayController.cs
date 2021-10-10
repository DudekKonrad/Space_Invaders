using System;
using System.Collections;
using Controllers.Enemies;
using Models;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class GameplayController : MonoBehaviour
    {
        public PlayerScriptable playerConfig;
        public GameplayScriptable gameplayConfig;
        public EnemySpawner enemySpawner;
        private void Update()
        {
            switch (GameplayModel.Instance.GameState)
            {
                //MAIN MENU
                case GameplayModel.GameStates.MainMenu:
                    break;
            
                //INIT STATE
                case GameplayModel.GameStates.Init:
                    GameplayModel.Instance.Lives = playerConfig.lives;
                    GameplayModel.Instance.Score = playerConfig.score;
                    GameplayModel.Instance.CurrWave = 0;
                    GameplayModel.Instance.IsUfoAlive = true;
                    GameplayModel.Instance.Shooting = GameplayModel.ShootingStyle.Single;
                    enemySpawner.InitWaves();
                    enemySpawner.SpawnAliens();
                    GameplayModel.Instance.CountdownTime = gameplayConfig.countDownTime;
                    GameplayModel.Instance.GameState = GameplayModel.GameStates.Countdown;
                    break;
                
                //COUNTDOWN STATE
                case GameplayModel.GameStates.Countdown:
                    StartCoroutine(CountdownToStart(GameplayModel.Instance.CountdownTime));
                    break;
                
                //GAMEPLAY STATE
                case GameplayModel.GameStates.Gameplay:
                    enemySpawner.CheckWave();
                    if (GameplayModel.Instance.Lives == 0 || !GameplayModel.Instance.IsUfoAlive)
                    {
                        GameplayModel.Instance.GameState = GameplayModel.GameStates.GameEnded;
                    }
                    break;
            
                //GAME ENDED STATE
                case GameplayModel.GameStates.GameEnded:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void StartMainMenu()
        {
            GameplayModel.Instance.GameState = GameplayModel.GameStates.MainMenu;
            SceneManager.LoadScene("MainMenu");
        }
        
        private static IEnumerator CountdownToStart(int countdownTime)
        {
            while (countdownTime >= 0)
            {
                yield return new WaitForSeconds(1.0f);
                countdownTime--;
                GameplayModel.Instance.CountdownTime = countdownTime;
            }
            yield return new WaitForSeconds(1.0f);
            GameplayModel.Instance.GameState = GameplayModel.GameStates.Gameplay;
        }
    }
}
