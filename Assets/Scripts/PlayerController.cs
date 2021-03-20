using UnityEngine;

[RequireComponent(typeof(PlayerInputMediator))]
public class PlayerController : MonoBehaviour
{
    private const float XRange = 8.0f;
    public GameObject projectilePrefab;
    public GameObject projectilePrefabClone;
    public AudioSource shootSound;
    public float speed = 10.0f;
    private PlayerInputMediator _playerInputMediator;

    void Start()
    {
        shootSound = gameObject.GetComponent<AudioSource>();
        _playerInputMediator = gameObject.GetComponent<PlayerInputMediator>();
        _playerInputMediator.Shoot += OnShoot;
        _playerInputMediator.Move += OnMove;
    }

    private void OnMove(float horizontalInput)
    {
        transform.Translate(horizontalInput * Time.deltaTime * speed * Vector3.right);
        if (transform.position.x < -XRange)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > XRange)
        {
            var position = transform.position;
            position = new Vector3(XRange, position.y, position.z);
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