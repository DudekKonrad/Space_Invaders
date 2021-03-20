using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y < -6.0f || gameObject.transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
