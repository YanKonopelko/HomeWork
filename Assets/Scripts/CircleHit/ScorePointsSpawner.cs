using System.Collections;
using UnityEngine;
namespace CircleHit
{
    public class ScorePointsSpawner : MonoBehaviour
    {
        [SerializeField] private float minTimeToSpawn = 0.5f;
        [SerializeField] private float maxTimeToSpawn = 1f;
        [SerializeField] private float timeBeforeFirstSpawn = 1.5f;
        [SerializeField] private float moveSpeedMax = 8;
        [SerializeField] private float moveSpeedMin = 6;
        [SerializeField] private GameObject pointPrefab = null;
        [SerializeField] private BoxCollider2D spawnBox = null;

        private void Start()
        {
            StartCoroutine(Timer(timeBeforeFirstSpawn));
        }

        private void Spawn()
        {
            Vector2 spawnPos = new Vector2(0,0);
            var boxTrans = spawnBox.GetComponent<Transform>();
            spawnPos.x = boxTrans.position.x;
            spawnPos.y = Random.Range(boxTrans.position.y-spawnBox.size.y/2,boxTrans.position.y+spawnBox.size.y/2);
            var obj = Instantiate(pointPrefab, transform);
            obj.GetComponent<ScorePoint>().SetSpeed(Random.Range(moveSpeedMin,moveSpeedMax));
            obj.transform.position = spawnPos;
            obj.GetComponent<ScorePoint>().SetScore(1);
        }

        IEnumerator Timer(float time)
        {
            yield return new WaitForSeconds(time);
            Spawn();
            StartCoroutine(Timer(Random.Range(minTimeToSpawn,maxTimeToSpawn)));
        }
    }

}
