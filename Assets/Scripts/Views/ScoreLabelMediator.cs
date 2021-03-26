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
            scoreText.text = $"Score: 0";
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
