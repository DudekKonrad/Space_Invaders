using UnityEngine;
using UnityEngine.UI;

public class WaveLabelMediator : MonoBehaviour
{
    public Text waveText;
    private int _lastWave = GameplayModel.Instance.Wave;

    private void Start()
    {
        waveText.text = $"Wave: {GameplayModel.Instance.Wave}";
    }

    private void Update()
    {
        if (GameplayModel.Instance.Wave != _lastWave )
        {
            _lastWave = GameplayModel.Instance.Score;
            waveText.text = $"Wave: {GameplayModel.Instance.Wave}";
        }
    }
}
