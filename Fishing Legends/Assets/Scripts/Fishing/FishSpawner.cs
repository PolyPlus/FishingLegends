using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public int numFish = 5;
    public BaitStateManager bait;
    public GameObject[] fishPrefabs;
    public Vector3[] spawnPositions;
    
    public GameObject[] fish;

    void Start()
    {
        fish = new GameObject[numFish];
        SpawnFish(numFish);       
    }

    public void SpawnFish(int n)
    {
        for(int i=0; i<n; i++)
        {
            int fishType = Random.Range(0, fishPrefabs.Length - 1);
            Quaternion randomRot = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            Vector3 randomPos = new Vector3(spawnPositions[i].x + Random.Range(0.0f, 0.5f), Random.Range(-4.0f, -2.5f), spawnPositions[i].z + Random.Range(0.0f, 0.5f));

            GameObject newFish = Instantiate(fishPrefabs[fishType], randomPos, randomRot, this.transform);
            newFish.GetComponent<FishStateManager>().bait = bait;
            fish[i] = newFish;
        }
    }
}
