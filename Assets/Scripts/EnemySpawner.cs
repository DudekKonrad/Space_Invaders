using Models;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] aliens = new GameObject[3];
    public GameObject enemiesContainer;
    private Wave[] _waves = new Wave[3];
    private int _waveNumber = GameplayModel.Instance.Wave;

    private void InitWave()
    {
        for (int i = 1; i < _waves.Length; i++)
        {
            _waves[i] = new Wave(_waveNumber*2, 3);
        }
    }
    public void SpawnAliens()
    {
        var xPos = -8.0f;
        var yPos = 3.5f;
        
        for (int i = 0; i < _waves[_waveNumber].Rows; i++)
        {
            for (int j = 0; j < _waves[_waveNumber].NumberOfAliensInRow; j++)
            {
                _waves[_waveNumber].AlienClone = Instantiate(aliens[i], enemiesContainer.transform);
                _waves[_waveNumber].AlienClone.transform.position = new Vector3(xPos, yPos, 0);
                xPos += 1.2f;   
            }
            yPos -= 1.1f;
            xPos = -8f;
        }
    }

    public void CheckWave()
    {
        if (enemiesContainer.gameObject.transform.childCount == 0 && _waveNumber == _waves.Length-1)
        {
            GameplayModel.Instance.GameState = GameplayModel.GameStates.GameEnded;
        }
        if (enemiesContainer.gameObject.transform.childCount == 0)
        {
            _waveNumber++;
            GameplayModel.Instance.Wave = _waveNumber;
            InitWave();
            SpawnAliens();
        }
    }

    private void Start()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
        {
            InitWave();
            SpawnAliens();
        }
    }

    private void Update()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
        {
            CheckWave();   
        }
    }


    private class Wave
    {
        public int NumberOfAliensInRow;
        public int Rows;
        public GameObject AlienClone;
        public Wave(int numberOfAliensInRow, int rows)
        {
            Rows = rows;
            NumberOfAliensInRow = numberOfAliensInRow;
        }
        
    }
}
