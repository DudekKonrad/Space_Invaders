using Controllers.Player;
using Models;
using ScriptableObjects;
using UnityEngine;

namespace Controllers.Bonus
{
    public class BonusController : MonoBehaviour
    {
        public GameObject bonusDrop;
        public ProjectileScriptable projectileConfig;
        
        private void Start()
        {
            Destroy(gameObject, projectileConfig.timeToDestroy + 2);
        }
        private void Update()
        {
            transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log($"Colission~!!aa");
            if (other.gameObject.GetComponent<PlayerController>())
            {
                Destroy(bonusDrop);
                GameplayModel.Instance.Shooting = GameplayModel.ShootingStyle.Double;
                Debug.Log($"Shooting: {GameplayModel.Instance.Shooting}");
            }
        }
    }
}
