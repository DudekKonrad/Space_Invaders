using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    public GameObject inputWindow;
    private Leaderboard.HighScore _playerHighScore;
    private int _highestHighScore;
    public InputField inputField;


    private void Start()
    {
        inputField.characterLimit = 7;
        var isEmpty = !HighScoreModel.Instance.HighScores.HighScoreList.Any();
        if (!isEmpty)
        {
            for (var i = 0; i < HighScoreModel.Instance.HighScores.HighScoreList.Count; i++)
            {
                for (var j = 0; j < HighScoreModel.Instance.HighScores.HighScoreList.Count; j++)
                {
                    if (HighScoreModel.Instance.HighScores.HighScoreList[j].score < HighScoreModel.Instance.HighScores.HighScoreList[i].score)
                    {
                        var tmp = HighScoreModel.Instance.HighScores.HighScoreList[i];
                        HighScoreModel.Instance.HighScores.HighScoreList[i] = HighScoreModel.Instance.HighScores.HighScoreList[j];
                        HighScoreModel.Instance.HighScores.HighScoreList[j] = tmp;
                    }
                }
            }

            _highestHighScore = HighScoreModel.Instance.HighScores.HighScoreList[HighScoreModel.Instance.HighScores.HighScoreList.Count - 1].score;
            HighScoreModel.Instance.SetHighScores();
        }
        else
        {
            _highestHighScore = -1;
        }
    }

    private void Update()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.GameEnded &&
            GameplayModel.Instance.Score > _highestHighScore)
        {
            inputWindow.gameObject.SetActive(true);
        }
    }

    public void AddToHighScores()
    {
        _playerHighScore = new Leaderboard.HighScore(GameplayModel.Instance.Score, inputField.text);
        HighScoreModel.Instance.HighScores.HighScoreList.Add(_playerHighScore);
        SceneManager.LoadScene("MainMenu");
    }
}