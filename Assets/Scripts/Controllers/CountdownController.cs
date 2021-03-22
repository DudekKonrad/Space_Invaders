using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class CountdownController : MonoBehaviour
    {
        public Text countdownDisplay;
        private int _lastTime = GameplayModel.Instance.CountdownTime;
        
        private void Update()
        {
            if (_lastTime != GameplayModel.Instance.CountdownTime)
            {
                countdownDisplay.text = GameplayModel.Instance.CountdownTime.ToString();   
            }
            if (GameplayModel.Instance.CountdownTime < 0)
            {
                countdownDisplay.gameObject.SetActive(false);
            }
        }
    }
}
