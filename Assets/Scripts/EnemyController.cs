using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private float _timer;
    private float timeToMove = 0.5f;
    private int _numOfMoves;
    private float _enemySpeed = 0.25f;
    private float _shootSpeed = 3500f;
    public GameObject enemy;
    public GameObject enemyProjectile;
    private EnemyMediator _enemyMediator;

    private void Start()
    {
        _enemyMediator = gameObject.GetComponent<EnemyMediator>();
        _enemyMediator.Shoot += ONEnemyShoot;
        _enemyMediator.Move += ONEnemyMove;
    }

    private void ONEnemyShoot()
    {
        if (Random.Range(0f, _shootSpeed) < 1 || enemyProjectile == null)
        {
            var position = enemy.transform.position;
            Instantiate(enemyProjectile, new Vector3(position.x, position.y - 0.4f,0), transform.rotation);
        }
    }

    private void ONEnemyMove()
    {
        _timer += Time.deltaTime;
        if (_timer > timeToMove && _numOfMoves < 9)
        {
            transform.Translate(new Vector3(_enemySpeed, 0, 0));
            _timer = 0;
            _numOfMoves++;
        }

        if (_numOfMoves == 9)
        {
            transform.Translate(new Vector3(0, -0.5f, 0));
            _numOfMoves = -9;
            _enemySpeed = -_enemySpeed;
            _timer = 0;
        }
    }
}
