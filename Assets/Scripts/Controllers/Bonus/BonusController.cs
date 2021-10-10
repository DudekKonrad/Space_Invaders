using Controllers.Player;
using Models;
using UnityEngine;

namespace Controllers.Bonus
{
    public class BonusController : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject, 5);
        }
        private void Update()
        {
            transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerController>())
            {
                Destroy(gameObject);
                GameplayModel.Instance.Shooting = GameplayModel.ShootingStyle.Double;
            }
        }
    }
}
