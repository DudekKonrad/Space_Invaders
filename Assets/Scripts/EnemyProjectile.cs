using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    public float speed = -4.0f;
    
    void Update()
    {
        transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(enemyProjectile);
            GameplayModel.Instance.Lives--;
        }

        if (other.gameObject.GetComponent<ShieldController>())
        {
            Destroy(enemyProjectile);
        }

        if (other.gameObject.GetComponent<PlayerProjectile>())
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}