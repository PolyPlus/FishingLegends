using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class RythmManager : MonoBehaviour, IPointerClickHandler
{
    public float initSpeed = 100;
    public GameObject latIz;
    public GameObject latDer;
    public GameObject anzuelo;
    public GameObject pez;
    public float tiempoAparicion;
    public GameObject panelRitmo;

    public BaitStateManager baitManager;

    public int size = 0; //3: GRANDE, 2: MEDIANO, 1: PEQUE

    private GameObject[] fish;
    private float timeFish=0;
    private int fishToSpawn;
    private int cont2;
    private int cont=0;
    private bool isActive = false;
    private bool comboFailed = false;

    private void Start()
    {
        startFishing();       
    }
    //Si empiezas a pescar, para todo el combo completo
    public void startFishing()
    {
        pez.GetComponent<RythmFish>().Init(this, latIz, latDer, initSpeed);
    }
    //Si pica pez
    public void startRythmGame()
    {
        cont = 0;
        cont2 = cont;
        timeFish = 0;
        fish = new GameObject[size];
        panelRitmo.SetActive(true);
        isActive = true;
        pez.GetComponent<RythmFish>().speed+=50;
        
    }
    //Cada PEZ que aparece según el tamaño, dentro del combo
    public void spawnFish()
    {
        Debug.Log("Spawn Fish");
        GameObject newFish;
        int randomChance = Random.Range(1, 101); //Crea un valor aleatorio del 1 al 100      
        if (randomChance <= 50)
        {
            newFish = Instantiate(pez, latDer.transform.position, latDer.transform.rotation) as GameObject;
        }
        else
        {
            newFish = Instantiate(pez, latIz.transform.position, latIz.transform.rotation) as GameObject;
        }
        newFish.transform.SetParent(gameObject.transform);

        timeFish = Time.time;
       // Debug.Log("tamano: "+tamano);
        fish[cont] = newFish;
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        // Vector2 pos = eventData.position;
        // Debug.Log("Pulsao, " + fish[cont2].transform.position.x+ ", aaa" + anzuelo.transform.position.x);
        float distance = Mathf.Abs(fish[cont2].transform.position.x - anzuelo.transform.position.x);
        if (distance <= 9.0f)
        {
            Debug.Log("EXCELENTE");
        }
        else if (distance <= 9.0f)
        {
            Debug.Log("BIEN");
        }
        else if (distance > 18.0f)
        {
            Debug.Log("MAL");
            Debug.Log("Distance " + distance);
            stopRythmGame();       
        }
        Destroy(fish[cont2]);
        ++cont2;
        if (cont2 >= size )
        {
            stopRythmGame();
        }

    }
    public void stopRythmGame()
    {
        panelRitmo.SetActive(false);
        isActive = false;
        for(int i=cont2;i<fish.Length;++i)
            Destroy(fish[i]);
        baitManager.StopRythmGame();
    }
    private void FixedUpdate()
    {
        if (isActive && (cont < fish.Length) && (Time.time - timeFish > tiempoAparicion))
        {

            spawnFish();
            ++cont;
        }
    }

}
