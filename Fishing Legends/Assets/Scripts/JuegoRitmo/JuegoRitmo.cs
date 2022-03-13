using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JuegoRitmo : MonoBehaviour, IPointerClickHandler
{
    public GameObject latIz;
    public GameObject latDer;
    public GameObject anzuelo;
    public GameObject pez;
    public float tiempoAparicion;
    public GameObject panelRitmo;


    public int tamano = 0; //3: GRANDE, 2: MEDIANO, 1: PEQUE

    private GameObject[] fish;

    private float timeFish=0;
    private int cont2;
    private int cont=0;
    private bool combo = false;

    private void Start()
    {
        startFishing();
       
    }
    //Si empiezas a pescar, para todo el combo completo
    public void startFishing()
    {
        pez.GetComponent<MuevePez>().speed = 100; //Se reinicia la veloc
    }
    //Si pica pez
    public void startCombo()
    {
        cont = 0;
        cont2 = cont;
        timeFish = 0;
        fish = new GameObject[tamano];
        panelRitmo.SetActive(true);
        combo = true;
        pez.GetComponent<MuevePez>().speed+=50;
        
    }
    //Cada PEZ que aparece según el tamaño, dentro del combo
    public void aparecePez()
    {
        
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
        newFish.transform.parent = gameObject.transform;

        timeFish = Time.time;
       // Debug.Log("tamano: "+tamano);
        fish[cont] = newFish;
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
       // Vector2 pos = eventData.position;
       // Debug.Log("Pulsao, " + fish[cont2].transform.position.x+ ", aaa" + anzuelo.transform.position.x);
        if (Mathf.Abs(fish[cont2].transform.position.x - anzuelo.transform.position.x) <= 4.0f)
        {
            Debug.Log("EXCELENTE");
        }
        else if (Mathf.Abs(fish[cont2].transform.position.x - anzuelo.transform.position.x) <= 8.0f)
        {
            Debug.Log("BIEN");
        }
        else if (Mathf.Abs(fish[cont2].transform.position.x - anzuelo.transform.position.x) > 8.0f)
        {
            Debug.Log("MAL");
            stopCombo();
          
        }
        Destroy(fish[cont2]);
        ++cont2;
        if (cont2 >= tamano )
        {
            stopCombo();
        }

    }
    public void stopCombo()
    {
        panelRitmo.SetActive(false);
        combo = false;
        for(int i=cont2;i<fish.Length;++i)
            Destroy(fish[i]);
    }
    private void Update()
    {
        if (combo)
        {
            if (cont < fish.Length)
            {
                if (Time.time - timeFish > tiempoAparicion)
                {
                    aparecePez();
                    ++cont;
                }
            }
        }
    }

}
