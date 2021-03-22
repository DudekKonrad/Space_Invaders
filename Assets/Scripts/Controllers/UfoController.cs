using Models;
using UnityEngine;

namespace Controllers
{
    public class UfoController : MonoBehaviour
    {
        private float speed = 5.0f;
        private Vector3 _moveDirection = Vector3.right;

        public void Update()
        {
            if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
            {
                transform.Translate(Time.deltaTime * speed * _moveDirection);
                if (transform.position.x < -12.0f)
                {
                    _moveDirection = Vector3.right;
                }
                else if (transform.position.x > 12.0f)
                {
                    _moveDirection = Vector3.left;
                }   
            }
        }
    }
}
