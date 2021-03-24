using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    public GameObject inputWindow;
    private HighScoreModel.HighScore _playerHighScore;
    private int _highestHighScore;
    public InputField inputField;


    private void Start()
    {
        inputField.characterLimit = 7;
        var isEmpty = !HighScoreModel.Instance.HighScoreList.Any();
        if (!isEmpty)
        {
            HighScoreModel.Instance.SortHighScores();
            _highestHighScore = HighScoreModel.Instance.HighScoreList[HighScoreModel.Instance.HighScoreList.Count - 1].score;
        }
        else
        {
            _highestHighScore = -1;
        }
    }

    private void Update()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.GameEnded && GameplayModel.Instance.Score > _highestHighScore)
        {
            inputWindow.gameObject.SetActive(true);
        }
    }

    public void AddToHighScores()
    {
        _playerHighScore = new HighScoreModel.HighScore(GameplayModel.Instance.Score, inputField.text);
        HighScoreModel.Instance.HighScoreList.Add(_playerHighScore);
        HighScoreModel.Instance.SortHighScores();
        HighScoreModel.Instance.SetHighScores();
        SceneManager.LoadScene("MainMenu");
    }
}