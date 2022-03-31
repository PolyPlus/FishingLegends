using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public int numFish = 5;
    public BaitStateManager bait;
    public GameObject[] fishShadows;
    public List<GameObject> fishPrefabs;
    public Vector3[] spawnPositions;
    
    public GameObject[] fish;
    public int[] fishWeights;

    void Start()
    {
        fish = new GameObject[numFish];
        fishWeights = new int[fishPrefabs.Count];
        GenerateWeights();
        SpawnFish(numFish);       
    }

    public void SpawnFish(int n)
    {
        for(int i=0; i<n; i++)
        {
            int fishTypeId = GetRandom(fishWeights);
            Debug.Log("Generating: " + fishPrefabs[fishTypeId] + " id: " + fishTypeId);
            int fishSize = fishPrefabs[fishTypeId].GetComponent<FishData>().Size;
            Quaternion randomRot = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
            Vector3 randomPos = new Vector3(spawnPositions[i].x + Random.Range(0.0f, 0.5f), Random.Range(-4.0f, -2.5f), spawnPositions[i].z + Random.Range(0.0f, 0.5f));
            GameObject fishShadow = fishShadows[fishSize];

            GameObject newFish = Instantiate(fishShadow, randomPos, randomRot, this.transform);
            newFish.GetComponent<FishStateManager>().Init(fishPrefabs[fishTypeId]);
            newFish.GetComponent<FishStateManager>().bait = bait;
            fish[i] = newFish;
        }
    }

    private void GenerateWeights()
    {
        for(int i = 0; i < fishPrefabs.Count; i++)
        {
            fishWeights[i] = fishPrefabs[i].GetComponent<FishData>().Rarity;
        }

    }

    public int GetRandom(int[] choices)
    {
        int sumWeight = 0;
        //Se calcula la suma de los pesos de cada opción
        for (int i = 0; i < choices.Length; i++)
        {
            sumWeight += choices[i];
        }
        //Se escoge un valor aleatorio entre 0 y el valor de la suma anterior
        int rnd = Random.Range(0, sumWeight);
        //Se recorre la lista de pesos hasta encontrar un peso inferior al valor aleatorio.
        //En caso de que el valor aleatorio sea superior, se le resta el valor del peso.
        for (int i = 0; i < choices.Length; i++)
        {
            if (rnd < choices[i]) return i;
            rnd -= choices[i];
        }
        return choices.Length - 1;
    }
}
