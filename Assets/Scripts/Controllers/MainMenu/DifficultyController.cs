using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers.MainMenu
{
    public class DifficultyController : MonoBehaviour
    {

        public EnemySpawnerScriptable enemySpawnerScriptable;
        public EnemyScriptable enemyScriptable;

        public void DifficultyCheck()
        {
            switch (GameplayModel.Instance.Difficulty)
            {
                case GameplayModel.Difficulties.Easy:
                    enemySpawnerScriptable.numberOfWaves = 3;
                    enemyScriptable.shootSpeed = 3500;
                    break;
                case GameplayModel.Difficulties.Medium:
                    enemySpawnerScriptable.numberOfWaves = 6;
                    enemyScriptable.shootSpeed = 2500;
                    break;
                case GameplayModel.Difficulties.Hard:
                    enemySpawnerScriptable.numberOfWaves = 10;
                    enemyScriptable.shootSpeed = 1000;
                    break;
            }
        }
    }
}
