using UnityEngine;
using UnityEngine.UI;

public class LifesLabelMediator : MonoBehaviour
{
    public Text lifesText;
    private int _lastLives;

    private void Start()
    {
        lifesText.text = $"Lives: {GameplayModel.Instance.Lives}";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayModel.Instance.Lives != _lastLives)
        {
            _lastLives = GameplayModel.Instance.Lives;
            lifesText.text = $"Lives: {GameplayModel.Instance.Lives}";
        }
    }
}
