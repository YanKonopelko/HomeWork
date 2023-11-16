using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    [SerializeField] private GameObject[] ObtaclePrefabs;
    [SerializeField] private Transform obstaclesParent;
    [SerializeField] private Vector2[] SpawnRanges ;
    private List<GameObject> _obstacles = new List<GameObject>();

    private void OnEnable()
    {
        instance = this;
    }
    

    public void SpawnObstacle(float YspawnPos)
    {
        
        if ( _obstacles.Any(t => t.transform.position.y == YspawnPos))
        {
            return;
        }
        int obstacleType = Random.Range(0, ObtaclePrefabs.Length);
        var obstacle = Instantiate(ObtaclePrefabs[obstacleType]);
        var spawnPos = new Vector2(0,YspawnPos);
        if (obstacleType == 0)
        {
            spawnPos.x = Random.Range(-2, 2);
        }
        else
        {
            var i = Random.Range(0, 3);
            spawnPos.x = Random.Range(SpawnRanges[i].x, SpawnRanges[i].y);
        }
        
        obstacle.transform.SetParent(obstaclesParent);
        obstacle.transform.position = spawnPos;
        _obstacles.Add(obstacle);
        if (_obstacles.Count == 9)
        {
            _obstacles[0].SetActive(false);
            _obstacles.Remove(_obstacles[0]);
        }
    }
}
