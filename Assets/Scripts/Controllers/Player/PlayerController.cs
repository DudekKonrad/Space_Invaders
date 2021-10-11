using Models;
using ScriptableObjects;
using UnityEngine;
using Views;

namespace Controllers.Player
{
    [RequireComponent(typeof(PlayerInputMediator))]
    public class PlayerController : MonoBehaviour
    {
        public PlayerScriptable playerConfig;
        public GameObject projectilePrefab;
        public GameObject projectileShoot;
        public AudioSource shootSound;
        private PlayerInputMediator _playerInputMediator;

        public void Start()
        {
            shootSound = gameObject.GetComponent<AudioSource>();
            _playerInputMediator = gameObject.GetComponent<PlayerInputMediator>();
            _playerInputMediator.Shoot += OnShoot;
            _playerInputMediator.Move += OnMove;
        }

        private void OnMove(float horizontalInput)
        {
            transform.Translate(horizontalInput * Time.deltaTime * playerConfig.speed * Vector3.right);
            if (transform.position.x < -playerConfig.xRange)
            {
                transform.position = new Vector3(-playerConfig.xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > playerConfig.xRange)
            {
                var position = transform.position;
                position = new Vector3(playerConfig.xRange, position.y, position.z);
                transform.position = position;
            }
        }

        private void OnShoot()
        {
            var projectiles = GameObject.FindGameObjectsWithTag("PlayerProjectile");
            if (projectiles.Length == 0)
            {
                var position = transform.position;
                var rotation = projectilePrefab.transform.rotation; 
                Instantiate(projectileShoot, gameObject.transform.position + new Vector3(0, 0.8f, 0), gameObject.transform.rotation);
                switch (GameplayModel.Instance.Shooting)
                {
                    case GameplayModel.ShootingStyle.Single:
                        Instantiate(projectilePrefab, position, rotation);
                        shootSound.PlayOneShot(shootSound.clip);
                        break;
                    case GameplayModel.ShootingStyle.Double:
                        Instantiate(projectilePrefab, position - new Vector3(0.2f, 0, 0), rotation);
                        Instantiate(projectilePrefab, position + new Vector3(0.2f, 0, 0), rotation);
                        shootSound.PlayOneShot(shootSound.clip);
                        break;
                }
            }
        }
    }
}