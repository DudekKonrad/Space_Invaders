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
        int size;
        if (HighScoreModel.Instance.HighScoreList.highScoreList.Count <= HighScoreModel.Instance.MAXSize)
        {
            size = HighScoreModel.Instance.HighScoreList.highScoreList.Count;
        }
        else
        {
            size = HighScoreModel.Instance.MAXSize;
        }
        var counter = 1;
        HighScoreModel.Instance.SortHighScores();
        for (var i = 0; i < size; i++)
        {
            var newHighScore = Instantiate(highScoreTemplate, highScoreContainer.transform);
            newHighScore.transform.Translate(Vector3.down * 20 * counter);
            newHighScore.transform.Find("posText").GetComponent<Text>().text = counter.ToString();
            newHighScore.transform.Find("scoreText").GetComponent<Text>().text = HighScoreModel.Instance.HighScoreList.highScoreList[i].score.ToString();
            newHighScore.transform.Find("nameText").GetComponent<Text>().text = HighScoreModel.Instance.HighScoreList.highScoreList[i].playerName;
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