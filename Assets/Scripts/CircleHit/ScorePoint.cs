using UnityEngine;
namespace CircleHit
{
public class ScorePoint : MonoBehaviour
{
    private int score;
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
            Collect();
        }
        if (other.collider.CompareTag("EnemyDestroyer"))
        { 
            SelfDestroy();
        }
    }
    public void SetScore(int Score){
        score = Score;
    }
    private void  SelfDestroy(){
        Destroy(gameObject);
    }

    private void Collect()
    {
        CircleHitScene.Instance.AddScore(score);
        SoundManager.instance.PlayAtPoint(SoundManager.SoundType.CollectSound,transform.position);
        SelfDestroy();
    }
}
}