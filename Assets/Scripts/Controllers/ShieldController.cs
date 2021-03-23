﻿using UnityEngine;

namespace Controllers
{
    public class ShieldController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        public Sprite[] sprites = new Sprite[9];

        private int _counter;

        private void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<EnemyProjectileController>() || other.gameObject.GetComponent<PlayerProjectileController>())
            {
                _counter++;
                _spriteRenderer.sprite = sprites[_counter];
                if (_counter == 8) 
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
