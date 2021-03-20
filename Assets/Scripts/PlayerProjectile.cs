using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject projectile;
    
    void Update()
    {
        transform.Translate(new Vector3(0, 4*Time.deltaTime, 0));
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
