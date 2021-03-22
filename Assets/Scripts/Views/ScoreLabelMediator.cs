using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ScoreLabelMediator : MonoBehaviour
    {
        public Text scoreText;
        private int _lastScore;

        private void Start()
        {
            //scoreText.text = "Score: " + GameplayModel.Instance.Score;
            //scoreText.text = string.Format("Score: {0}", GameplayModel.Instance.Score);
            scoreText.text = $"Score: {GameplayModel.Instance.Score}";
        }

        private void Update()
        {
            if (GameplayModel.Instance.Score != _lastScore)
            {
                _lastScore = GameplayModel.Instance.Score;
                scoreText.text = $"Score: {GameplayModel.Instance.Score}";
            }
        }
    }
}
