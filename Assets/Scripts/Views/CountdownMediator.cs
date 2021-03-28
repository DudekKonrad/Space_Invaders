using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CountdownMediator : MonoBehaviour
    {
        public Text scoreText;
        private int _lastCountDownTime;

        private void Start()
        {
            scoreText.text = $"{GameplayModel.Instance.CountdownTime}";
        }

        private void Update()
        {
            if (GameplayModel.Instance.CountdownTime == 0)
            {
                scoreText.text = "GO!";
            }
            if (GameplayModel.Instance.CountdownTime == -1)
            {
                scoreText.gameObject.SetActive(false);
            }
            if (GameplayModel.Instance.CountdownTime != _lastCountDownTime)
            {
                _lastCountDownTime = GameplayModel.Instance.Score;
                scoreText.text = $"{GameplayModel.Instance.CountdownTime}";
            }
        }
    }
}
