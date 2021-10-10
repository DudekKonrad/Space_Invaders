using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class EndGamePopupMediator : MonoBehaviour
    {
        public GameObject endGamePanel;
        public Text finalScoreText;
        public Text highScoreText;

        private void Update()
        {
            if (GameplayModel.Instance.GameState == GameplayModel.GameStates.GameEnded)
            {
                StartEndGamePopup();
            }
            else
            {
                endGamePanel.gameObject.SetActive(false);
            }
        }

        private void StartEndGamePopup()
        {
            endGamePanel.gameObject.SetActive(true);
            finalScoreText.text = $"Your Score: {GameplayModel.Instance.Score}";
            var isEmpty = !HighScoreModel.Instance.HighScoreList.highScoreList.Any();
            if (isEmpty)
            {
                highScoreText.text = $"High Score: 0";    
            }
            else
            {
                highScoreText.text = $"High Score: {HighScoreModel.Instance.HighScoreList.highScoreList[0].score}";   
            }
        }
    }
}
