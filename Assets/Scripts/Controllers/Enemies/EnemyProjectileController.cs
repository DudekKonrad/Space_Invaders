using Controllers.Player;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers.Enemies
{
    public class EnemyProjectileController : MonoBehaviour
    {
        public GameObject enemyProjectile;
        public ProjectileScriptable projectileConfig;
        public GameObject explosion;

        private void Start()
        {
            Destroy(gameObject, projectileConfig.timeToDestroy);
        }

        private void Update()
        {
            transform.Translate(new Vector3(0, projectileConfig.speed * Time.deltaTime, 0));
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(enemyProjectile);
                GameplayModel.Instance.Lives--;
            }

            if (other.gameObject.GetComponent<ShieldController>())
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(enemyProjectile);
            }

            if (other.gameObject.GetComponent<PlayerProjectileController>())
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}