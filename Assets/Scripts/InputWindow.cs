using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    public GameObject inputWindow;
    private Leaderboard.HighScores _highScores;
    private Leaderboard.HighScore _playerHighScore;
    private int _highestHighScore;
    public InputField inputField;


    private void Start()
    {
        inputField.characterLimit = 7;
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        _highScores = JsonUtility.FromJson<Leaderboard.HighScores>(jsonString);
        bool isEmpty = !_highScores.HighScoreList.Any();
        Debug.Log($"Is empty:{isEmpty}");
        Debug.Log($"List: {_highScores.HighScoreList}");
        if (!isEmpty)
        {
            for (int i = 0; i < _highScores.HighScoreList.Count; i++)
            {
                Debug.Log($"{_highScores.HighScoreList[i].playerName}: ");
                Debug.Log($"{_highScores.HighScoreList[i].score}: ");
                for (int j = 0; j < _highScores.HighScoreList.Count; j++)
                {
                    if (_highScores.HighScoreList[j].score < _highScores.HighScoreList[i].score)
                    {
                        var tmp = _highScores.HighScoreList[i];
                        _highScores.HighScoreList[i] = _highScores.HighScoreList[j];
                        _highScores.HighScoreList[j] = tmp;
                    }
                }
            }
            _highestHighScore = _highScores.HighScoreList[0].score;
            string json = JsonUtility.ToJson(_highScores);
            PlayerPrefs.SetString("highScoreTable", json);
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
        _playerHighScore = new Leaderboard.HighScore(GameplayModel.Instance.Score, inputField.text);
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        _highScores = JsonUtility.FromJson<Leaderboard.HighScores>(jsonString);
        _highScores.HighScoreList.Add(_playerHighScore);
        string json = JsonUtility.ToJson(_highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        SceneManager.LoadScene("MainMenu");
    }
    
}
