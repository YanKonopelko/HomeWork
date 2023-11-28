using UnityEngine;

namespace CircleHit
{
    public class Wall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Player>().Kill();
            }
        }
        
    }
}
  