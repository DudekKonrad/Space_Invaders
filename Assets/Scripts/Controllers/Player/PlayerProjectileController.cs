using Controllers.Enemies;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerProjectileController : MonoBehaviour
    {
        public GameObject projectile;
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
                Destroy(other.gameObject);
                Destroy(projectile);
                GameplayModel.Instance.Score++;
            }

            if (other.gameObject.GetComponent<UfoController>())
            {
                GameplayModel.Instance.IsUfoAlive = false;
            }

            if (other.gameObject.GetComponent<ShieldController>())
            {
                Destroy(projectile);
            }
        }
    }
}
