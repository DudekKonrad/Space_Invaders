using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public GameObject highScoreContainer;
    public GameObject highScoreTemplate;
    private int _counter = 1;
    public GameObject highScoreTable;


    [System.Serializable]
    public class HighScore
    {
        public int score;
        public string playerName;
        
        public HighScore(int score, string playerName)
        {
            this.score = score;
            this.playerName = playerName;
        }
    }
    
    public class HighScores
    {
        public List<HighScore> HighScoreList;
    }

    public void SortList(List<HighScore> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            for (var j = 0; j < list.Count; j++)
            {
                if (list[j].score < list[i].score)
                {
                    var tmp = list[i];
                    list[i] = list[j];
                    list[j] = tmp;
                }
            }
        }
    }

    public void LoadTable()
    {
        var highScores = HighScoreModel.Instance.HighScores;
        SortList(highScores.HighScoreList);
        foreach (var highScore in highScores.HighScoreList)
        {
            var newHighScore = Instantiate(highScoreTemplate, highScoreContainer.transform);
            newHighScore.transform.Translate(Vector3.down * 20 * _counter);
            newHighScore.transform.Find("posText").GetComponent<Text>().text = _counter.ToString();
            newHighScore.transform.Find("scoreText").GetComponent<Text>().text = highScore.score.ToString();
            newHighScore.transform.Find("nameText").GetComponent<Text>().text = highScore.playerName;
            newHighScore.SetActive(true);
            _counter++;
        }
        highScoreTable.gameObject.SetActive(true);
        _counter = 0;
    }

    public void CloseTable()
    {
        highScoreTable.gameObject.SetActive(false);
    }
}