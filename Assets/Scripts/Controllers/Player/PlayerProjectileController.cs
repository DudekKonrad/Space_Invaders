using Controllers.Enemies;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerProjectileController : MonoBehaviour
    {
        public GameObject projectile;
        public GameObject explosion;
        public ProjectileScriptable projectileConfig;

        private void Start()
        {
            Destroy(gameObject, projectileConfig.timeToDestroy);
        }

        public void Update()
        {
            transform.Translate(new Vector3(0, projectileConfig.speed * Time.deltaTime, 0));
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<EnemyController>())
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(other.gameObject);
                Destroy(projectile);
                GameplayModel.Instance.Score++;
            }

            if (other.gameObject.GetComponent<UfoController>())
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                GameplayModel.Instance.IsUfoAlive = false;
            }

            if (other.gameObject.GetComponent<ShieldController>())
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(projectile);
            }
        }
    }
}
