using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    
    void Update()
    {
        transform.Translate(new Vector3(0, -4*Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(enemyProjectile);
            GameplayModel.Instance.Lives--;
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(enemyProjectile);
        }
    }
}