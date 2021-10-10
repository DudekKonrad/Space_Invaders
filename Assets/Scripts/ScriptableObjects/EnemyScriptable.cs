using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/Enemy")]
    public class EnemyScriptable : ScriptableObject
    {
        public float enemySpeed;
        public float shootSpeed;
        public float dropRate;
        public int numberOfMoves;
        public float enemyTimeToMove;
    }
}
