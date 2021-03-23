using ScriptableObjects;
using UnityEngine;
using Views;

namespace Controllers
{
    [RequireComponent(typeof(PlayerInputMediator))]
    public class PlayerController : MonoBehaviour
    {
        public PlayerScriptable playerConfig;
        public GameObject projectilePrefab;
        public GameObject projectilePrefabClone;
        public AudioSource shootSound;
        public float speed = 10.0f;
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
            transform.Translate(horizontalInput * Time.deltaTime * speed * Vector3.right);
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
            if (projectilePrefabClone == null)
            {
                projectilePrefabClone = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
                shootSound.PlayOneShot(shootSound.clip);
            }
        }
    }
}