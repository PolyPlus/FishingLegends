using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3[] spawnPositions;
    public bool isActive;
    public BossFightManager bossFightManager;

    private float spawnTime;
    private float timeToSpawn;
    private int numObstacles;

    public float SpawnTime { get => spawnTime; set => spawnTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = SpawnTime;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if(numObstacles > 0)
            {
                timeToSpawn -= Time.deltaTime;
                if (timeToSpawn <= 0)
                {
                    numObstacles--;
                    timeToSpawn = SpawnTime;
                    Spawn(GetRandomPos());
                }
            }
            else
            {
                isActive = false;
                bossFightManager.Waiting = true;
            }
            
        }        
    }

    private Vector3 GetRandomPos()
    {
        int i = Random.Range(0, 3);
        Vector3 spawnPos = spawnPositions[i] + transform.position;
        return spawnPos;
    }

    private void Spawn(Vector3 pos)
    {
        GameObject newObj = Instantiate(prefab, pos, Quaternion.identity, transform);
    }

    public void StartSpawning(int obstacles, float time)
    {
        Debug.Log("Start Spawning");
        numObstacles = obstacles;
        spawnTime = time;
        isActive = true;
    }
}
