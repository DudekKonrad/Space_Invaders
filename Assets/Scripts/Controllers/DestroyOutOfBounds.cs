using UnityEngine;

namespace Controllers
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        private void Update()
        {
            if (gameObject.transform.position.y < -6.0f || gameObject.transform.position.y > 6.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
