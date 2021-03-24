using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemySpawnerScriptable enemySpawnerConfig;
        public GameObject enemiesContainer;
        private Wave[] _waves;
        public GameObject alienClone;
        private int currWave => GameplayModel.Instance.CurrWave;

        public class Wave
        {
            public int NumberOfAliensInRow;
            public int Rows;

            public Wave(int numberOfAliensInRow, int rows)
            {
                Rows = rows;
                NumberOfAliensInRow = numberOfAliensInRow;
            }
        }
        public void InitWaves()
        {
            _waves = new Wave[enemySpawnerConfig.numberOfWaves];
            for (var i = 0; i < _waves.Length; i++)
            {
                _waves[i] = new Wave(i+1, 3);
                Debug.Log($"Wave[{i}]: {_waves[i].NumberOfAliensInRow}");
            }
        }
        public void SpawnAliens()
        {
            var xPos = (-currWave + 0f)/1.5f;
            var yPos = 3.5f;
            for (var i = 0; i < _waves[currWave].Rows; i++)
            {
                for (var j = 0; j < _waves[currWave].NumberOfAliensInRow; j++)
                {
                    alienClone = Instantiate(enemySpawnerConfig.aliens[i], enemiesContainer.transform);
                    alienClone.transform.position = new Vector3(xPos, yPos, 0);
                    xPos += 1.2f;   
                }
                yPos -= 1.1f;
                xPos = (-currWave + 0f)/1.5f;
            }
            GameplayModel.Instance.NumberOfEnemies = enemiesContainer.transform.childCount;
        }

        public void CheckWave()
        {
            if (enemiesContainer.transform.childCount == 0)
            {
                Debug.Log("Next Wave is coming!");
                GameplayModel.Instance.CurrWave++;
                SpawnAliens();
            }
        }
    }
}
