using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class WaveLabelMediator : MonoBehaviour
    {
        public Text waveText;
        private int _lastWave = GameplayModel.Instance.CurrWave;

        private void Start()
        {
            waveText.text = $"Wave: {GameplayModel.Instance.CurrWave}";
        }

        private void Update()
        {
            if (GameplayModel.Instance.CurrWave != _lastWave )
            {
                _lastWave = GameplayModel.Instance.Score;
                waveText.text = $"Wave: {GameplayModel.Instance.CurrWave}";
            }
        }
    }
}
