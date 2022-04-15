using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    public float spawnTime;
    public bool isActive;

    private float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        timeToSpawn = spawnTime;
    }


    public void Spawn()
    {
        GameObject newWater = Instantiate(waterPrefab, transform);
        newWater.GetComponent<WaterMovement>().Spawner = this;
    }
}
