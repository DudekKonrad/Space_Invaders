using Models;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject highScoreContainer;
    public GameObject highScoreTemplate;
    public GameObject highScoreTable;
    

    public void LoadTable()
    {
        var counter = 0;
        HighScoreModel.Instance.SortHighScores();
        foreach (var highScore in HighScoreModel.Instance.HighScoreList)
        {
            var newHighScore = Instantiate(highScoreTemplate, highScoreContainer.transform);
            newHighScore.transform.Translate(Vector3.down * 20 * counter);
            newHighScore.transform.Find("posText").GetComponent<Text>().text = counter.ToString();
            newHighScore.transform.Find("scoreText").GetComponent<Text>().text = highScore.score.ToString();
            newHighScore.transform.Find("nameText").GetComponent<Text>().text = highScore.playerName;
            newHighScore.SetActive(true);
            counter++;
        }
        highScoreTable.gameObject.SetActive(true);
    }

    public void CloseTable()
    {
        highScoreTable.gameObject.SetActive(false);
    }
}