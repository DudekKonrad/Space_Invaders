using System;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class HighScoreModel:Singleton<HighScoreModel>
    {
        public Hs HighScoreList;
        public int MAXSize = 10;
        public bool Init = false;
        
        public void ResetHighScores()
        {
            HighScoreList.highScoreList.Clear();
            SetHighScores();
        }

        public static Hs GetHighScores()
        {
            var jsonString = PlayerPrefs.GetString("highScoreTable");
            var list = JsonUtility.FromJson<Hs>(jsonString);
            return list;
        }

        public void SetHighScores()
        {
            string json = JsonUtility.ToJson(HighScoreList);
            Debug.Log($"Json in set: {json}");
            PlayerPrefs.SetString("highScoreTable", json);
        }
        
        [Serializable]
        public class Hs
        {
            public List<HighScore> highScoreList = new List<HighScore>();

            public void Print()
            {
                Debug.Log($"Size: {highScoreList.Count}");
                foreach (var element in highScoreList)
                {
                    Debug.Log($"Name: {element.playerName}, Score: {element.score}");
                }
            }
        }
        [Serializable]
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
            for (var i = 0; i < HighScoreList.highScoreList.Count; i++)
            {
                for (var j = 0; j < HighScoreList.highScoreList.Count; j++)
                {
                    if (HighScoreList.highScoreList[j].score < HighScoreList.highScoreList[i].score)
                    {
                        var tmp = HighScoreList.highScoreList[i];
                        HighScoreList.highScoreList[i] = HighScoreList.highScoreList[j];
                        HighScoreList.highScoreList[j] = tmp;
                    }
                }
            }
        }

        public void InitHighScores()
        {
            PlayerPrefs.DeleteAll();
            if (!Init)
            {
                HighScoreList = GetHighScores();
                Debug.Log($"in init");
                if (HighScoreList == null)
                {
                    Debug.Log("Is null");
                    HighScoreList = new Hs();
                    SetHighScores();
                }
                else
                {
                    Debug.Log($"IS not null");
                    Debug.Log($"{HighScoreList.highScoreList}");
                }
            }

            Init = true;
        }
    }
}
