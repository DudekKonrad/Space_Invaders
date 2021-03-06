using Controllers.Player;
using Models;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        private float _timer;
        private int _numOfMoves;
        private int _direction = 1;
        public GameObject enemy;
        public GameObject enemyProjectile;
        public EnemyScriptable enemyConfig;
        public GameObject bonusDrop;

        private void OnCollisionEnter2D (Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerProjectileController>())
            {
                EnemyDrop();
            }

            if (other.gameObject.GetComponent<ShieldController>())
            {
                GameplayModel.Instance.Lives = 0;
            }
        }

        private void Update()
        {
            if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
            {
                EnemyMove();
                EnemyWin();
                EnemyShoot();
            }
        }

        private void EnemyShoot()
        {
            if (Random.Range(0f, enemyConfig.shootSpeed) < 1 || enemyProjectile == null)
            {
                var position = enemy.transform.position;
                Instantiate(enemyProjectile, new Vector3(position.x, position.y - 0.4f,0), transform.rotation);
            }
        }

        private void EnemyMove()
        {
            _timer += Time.deltaTime;
            if (_timer > enemyConfig.enemyTimeToMove && _numOfMoves < enemyConfig.numberOfMoves)
            {
                transform.Translate(new Vector3(enemyConfig.enemySpeed * _direction, 0, 0));
                _timer = 0;
                _numOfMoves++;
            }

            if (_numOfMoves == enemyConfig.numberOfMoves)
            {
                transform.Translate(new Vector3(0, -0.5f, 0));
                _numOfMoves = -enemyConfig.numberOfMoves;
                _direction = -_direction;
                _timer = 0;
            }
        }

        private void EnemyDrop()
        {
            if (Random.Range(0f, enemyConfig.dropRate) < 1)
            {
                var position = enemy.transform.position;
                Instantiate(bonusDrop, new Vector3(position.x, position.y - 0.4f,0), transform.rotation);
            }
        }

        private void EnemyWin()
        {
            if (gameObject.transform.position.y <= -3f)
            {
                GameplayModel.Instance.Lives = 0;
            }
        }
    }
}
