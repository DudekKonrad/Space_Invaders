using System.Collections;
using Controllers.Player;
using Models;
using UnityEngine;

namespace Controllers.Bonus
{
    public class BonusController : MonoBehaviour
    {
        [SerializeField] private float _timeToDestroy;
        [SerializeField] private float _speed;
        [SerializeField] private int _timeOfBonus;
        private void Start()
        {
            Destroy(gameObject, _timeToDestroy);
        }
        private void Update()
        {
            transform.Translate(new Vector3(0, -_speed * Time.deltaTime, 0));
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
