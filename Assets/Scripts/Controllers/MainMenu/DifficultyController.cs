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
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Easy;
                    Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                    break;
                case 1:
                    enemySpawnerScriptable.numberOfWaves = 6;
                    enemyScriptable.shootSpeed = 2500;
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Medium;
                    Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                    break;
                case 2:
                    enemySpawnerScriptable.numberOfWaves = 10;
                    enemyScriptable.shootSpeed = 1000;
                    GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Hard;
                    Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                    break;
            }
        }
    }
}
