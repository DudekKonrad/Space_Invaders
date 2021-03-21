﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private void Update()
    {
        switch (GameplayModel.Instance.GameState)
        {
            //MAIN MENU
            case GameplayModel.GameStates.MainMenu:
                break;
            
            //INIT STATE
            case GameplayModel.GameStates.Init:
                GameplayModel.Instance.Lives = 3;
                GameplayModel.Instance.Score = 0;
                GameplayModel.Instance.Wave = 1;
                GameplayModel.Instance.IsUfoAlive = true;
                SceneManager.LoadScene("Game");
                GameplayModel.Instance.GameState = GameplayModel.GameStates.Gameplay;
                break;
            
            //GAMEPLAY STATE
            case GameplayModel.GameStates.Gameplay:
                if (GameplayModel.Instance.Lives == 0 || !GameplayModel.Instance.IsUfoAlive)
                {
                    EndGame();
                }
                break;
            
            //GAME ENDED STATE
            case GameplayModel.GameStates.GameEnded:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void EndGame()
    {
        GameplayModel.Instance.GameState = GameplayModel.GameStates.GameEnded;
    }

    public void StartGame()
    {
        GameplayModel.Instance.GameState = GameplayModel.GameStates.Init;
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameplayModel.Instance.GameState = GameplayModel.GameStates.MainMenu;
    }
}
