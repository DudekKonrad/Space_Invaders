﻿using UnityEngine;
using UnityEngine.UI;

public class EndGamePopupMediator : MonoBehaviour
{
    private Leaderboard _leaderboard;
    public GameObject endGamepanel;
    public Text finalScoreText;
    public Text highScoreText;

    private void Update()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.GameEnded)
        {
            StartEndGamePopup();
        }
        else
        {
            endGamepanel.gameObject.SetActive(false);
        }
    }

    private void StartEndGamePopup()
    {
        endGamepanel.gameObject.SetActive(true);
        finalScoreText.text = $"Your Score: {GameplayModel.Instance.Score}";
        highScoreText.text = $"High Score: {_leaderboard.GetHighScores().HighScoreList[0].score}";
    }
}
