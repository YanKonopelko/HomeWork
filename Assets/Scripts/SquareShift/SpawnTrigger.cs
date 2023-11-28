using UnityEngine;

namespace SquareShift
{
    public class SpawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Triggered");
                LevelGenerator.instance.SpawnObstacle(transform.position.y + 6f);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Triggered");
                LevelGenerator.instance.SpawnObstacle(transform.position.y + 6f);
                Destroy(gameObject);
            }
        }
    }
}