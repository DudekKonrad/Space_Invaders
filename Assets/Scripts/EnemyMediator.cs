﻿using UnityEngine;
using UnityEngine.Events;

public class EnemyMediator : MonoBehaviour
{
    public UnityAction Shoot;
    public UnityAction Move;

    private void Update()
    {
        if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
        {
            Move?.Invoke();
            Shoot?.Invoke();
        }
    }
}
