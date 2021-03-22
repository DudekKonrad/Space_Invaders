using Models;
using UnityEngine;
using UnityEngine.Events;

namespace Views
{
    public class PlayerInputMediator : MonoBehaviour
    {
        public UnityAction Shoot;
        public UnityAction<float> Move;

        private void Update()
        {
            if (GameplayModel.Instance.GameState == GameplayModel.GameStates.Gameplay)
            {
                var horizontalInput = Input.GetAxis("Horizontal");

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Shoot?.Invoke();
                }

                if (horizontalInput != 0)
                {
                    Move?.Invoke(horizontalInput);
                }   
            }
        }
    }
}
