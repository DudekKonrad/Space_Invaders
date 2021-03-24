using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New EnemySpawner", menuName = "Game/EnemySpawner")]
    public class EnemySpawnerScriptable : ScriptableObject
    {
        public GameObject[] aliens;
        public int numberOfWaves;
    }
}
