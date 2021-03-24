using UnityEngine;

namespace Models
{
    public class HighScoreModel:Singleton<HighScoreModel>
    {
        public Leaderboard.HighScores HighScores { get; set; } = GetHighScores();
        public void ResetHighScores()
        {
            var highScores = GetHighScores();
            highScores.HighScoreList.Clear();
            SetHighScores();
        }

        public static Leaderboard.HighScores GetHighScores()
        {
            var jsonString = PlayerPrefs.GetString("highScoreTable");
            Leaderboard.HighScores highScores = JsonUtility.FromJson<Leaderboard.HighScores>(jsonString);
            return highScores;
        }

        public void SetHighScores()
        {
            string json = JsonUtility.ToJson(HighScores);
            PlayerPrefs.SetString("highScoreTable", json);
        }
    }
}
