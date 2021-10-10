using Models;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.MainMenu
{
    public class DifficultyController : MonoBehaviour
    {

        public EnemySpawnerScriptable enemySpawnerScriptable;
        public EnemyScriptable enemyScriptable;
        public Dropdown difficultyDropdown;

        public void ValueChange()
        {
            switch (difficultyDropdown.value)
            {
                case 0:
                    enemySpawnerScriptable.numberOfWaves = 3;
                    enemyScriptable.shootSpeed = 3500;
                    enemyScriptable.enemyTimeToMove = 0.5f;
                    enemyScriptable.dropRate = 100;
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Easy;
                    break;
                case 1:
                    enemySpawnerScriptable.numberOfWaves = 6;
                    enemyScriptable.shootSpeed = 2500;
                    enemyScriptable.enemyTimeToMove = 0.25f;
                    enemyScriptable.dropRate = 200;
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Medium;
                    break;
                case 2:
                    enemySpawnerScriptable.numberOfWaves = 10;
                    enemyScriptable.shootSpeed = 1000;
                    enemyScriptable.enemyTimeToMove = 0.1f;
                    enemyScriptable.dropRate = 500;
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Hard;
                    break;
            }
        }
    }
}
