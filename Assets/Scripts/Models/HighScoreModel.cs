using UnityEngine;

namespace Models
{
    public class HighScoreModel
    {
        public void ResetHighScores()
        {
            var highScores = GetHighScores();
            highScores.HighScoreList.Clear();
            SetHighScores(highScores);
        }

        public static Leaderboard.HighScores GetHighScores()
        {
            var jsonString = PlayerPrefs.GetString("highScoreTable");
            Leaderboard.HighScores highScores = JsonUtility.FromJson<Leaderboard.HighScores>(jsonString);
            return highScores;
        }

        public static void SetHighScores(Leaderboard.HighScores highScores)
        {
            string json = JsonUtility.ToJson(highScores);
            PlayerPrefs.SetString("highScoreTable", json);
        }
    }
}
