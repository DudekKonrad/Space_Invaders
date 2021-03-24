using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class HighScoreModel:Singleton<HighScoreModel>
    {
        public List<HighScore> HighScoreList = new List<HighScore>();
        public void ResetHighScores()
        {
            HighScoreList.Clear();
            SetHighScores();
        }

        public static List<HighScore> GetHighScores()
        {
            var jsonString = PlayerPrefs.GetString("highScoreTable");
            var list = JsonUtility.FromJson<List<HighScore>>(jsonString);
            return list;
        }

        public void SetHighScores()
        {
            string json = JsonUtility.ToJson(HighScoreList);
            PlayerPrefs.SetString("highScoreTable", json);
        }
        
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

        public void SortHighScores()
        {
            for (var i = 0; i < HighScoreList.Count; i++)
            {
                for (var j = 0; j < HighScoreList.Count; j++)
                {
                    if (HighScoreList[j].score < HighScoreList[i].score)
                    {
                        var tmp = HighScoreList[i];
                        HighScoreList[i] = HighScoreList[j];
                        HighScoreList[j] = tmp;
                    }
                }
            }
        }

        public void InitHighScores()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log($"Przed get: {HighScoreList.Count}");
            GetHighScores();
            Debug.Log($"Po gecie: {HighScoreList.Count}");
            if (HighScoreList == null)
            {
                Debug.Log($"Setowanie");
                SetHighScores();
            }
        }
    }
}
