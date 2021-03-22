using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class LifesLabelMediator : MonoBehaviour
    {
        public Text lifesText;
        private int _lastLives;

        private void Start()
        {
            lifesText.text = $"Lives: {GameplayModel.Instance.Lives}";
        }

        public void Update()
        {
            if (GameplayModel.Instance.Lives != _lastLives)
            {
                _lastLives = GameplayModel.Instance.Lives;
                lifesText.text = $"Lives: {GameplayModel.Instance.Lives}";
            }
        }
    }
}
