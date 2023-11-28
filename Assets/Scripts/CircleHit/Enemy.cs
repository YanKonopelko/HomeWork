using System;
using UnityEngine;

namespace CircleHit
{
    public class Enemy : MonoBehaviour
    {

        private float moveSpeed;
        private Transform _transform;

        private void OnEnable()
        {
            _transform = transform;
        }

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            _transform.position += new Vector3(moveSpeed*Time.deltaTime,0,0);
        }

        public void SetSpeed(float speed)
        {
            moveSpeed = speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {

            if (other.collider.CompareTag("Player"))
            {
                other.collider.GetComponent<Player>().Kill();
            }

            if (other.collider.CompareTag("EnemyDestroyer"))
            { 
                DestroyEnemy();
            }
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}