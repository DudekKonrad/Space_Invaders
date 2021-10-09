using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyMediator : MonoBehaviour
{
    public Dropdown difficultyDropdown;

    public void ValueChange()
    {
        switch (difficultyDropdown.value)
        {
            case 0:
                GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Easy;
                Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                break;
            case 1:
                GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Medium;
                Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                break;
            case 2:
                GameplayModel.Instance.Difficulty = GameplayModel.Difficulties.Hard;
                Debug.Log($"Difficulty Level: {GameplayModel.Instance.Difficulty}");
                break;
        }
    }
}
