using Controllers.Player;
using Models;
using UnityEngine;

namespace Controllers.Enemies
{
    public class EnemyGroupController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerProjectileController>() || other.gameObject.GetComponent<ShieldController>())
            {
                GameplayModel.Instance.Lives = 0;
            }
        }
    }
}
