using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmManager : MonoBehaviour
{
    public bool started = false;
    public bool bossFight = false;
    public float initSpeed = 200;
    public float speed;
    public GameObject latIz;
    public GameObject latDer;
    public GameObject bait;
    public GameObject pez;
    public float tiempoAparicion;
    public GameObject panelRitmo;

    public EvaluationTexts textScript;

    public int size = 0; //3: GRANDE, 2: MEDIANO, 1: PEQUE
    
    private int score;
    private bool isActive = false;
    private GameObject[] fish;
    private float timeFish = 0;
    private int currentFish;
    private int lastFish = 0;
    private BossFightManager bossManager;
    private BaitStateManager baitManager;

    public BaitStateManager BaitManager { get => baitManager; set => baitManager = value; }
    public BossFightManager BossManager { get => bossManager; set => bossManager = value; }

    private void Start()
    {
        ResetSpeed();
        startFishing();
    }

    private void FixedUpdate()
    {
        if (isActive && (lastFish < fish.Length))
        {
            if(Time.time - timeFish > tiempoAparicion)
            {
                spawnFish();
                ++lastFish;
            }          
        }
    }

    //Si empiezas a pescar, para todo el combo completo
    public void startFishing()
    {       
        pez.GetComponent<RythmFish>().Init(this, latIz, latDer, speed);
    }
    //Si pica pez
    public void startRythmGame(int numFish)
    {
        score = 0;
        size = numFish;
        lastFish = 0;
        currentFish = lastFish;
        timeFish = Time.time;
        fish = new GameObject[size];
        panelRitmo.SetActive(true);
        isActive = true;
        speed += 50;
        pez.GetComponent<RythmFish>().speed = speed;

    }

    public void startRythmGame(int numFish, float _speed)
    {
        score = 0;
        size = numFish;
        lastFish = 0;
        currentFish = lastFish;
        timeFish = Time.time;
        fish = new GameObject[size];
        panelRitmo.SetActive(true);
        isActive = true;
        speed = _speed;
        pez.GetComponent<RythmFish>().speed = speed;

    }

    //Cada PEZ que aparece según el tamaño, dentro del combo
    public void spawnFish()
    {
        //GameObject newFish;
        GameObject newFish = Instantiate(pez) as GameObject;
        int randomChance = Random.Range(1, 101); //Crea un valor aleatorio del 1 al 100      
        if (randomChance <= 50)
        {
            newFish.transform.SetParent(latDer.transform, false);
        }
        else
        {
            newFish.transform.SetParent(latIz.transform, false);
        }
        newFish.GetComponent<RythmFish>().Init(this, latIz, latDer, speed);

        timeFish = Time.time;
        fish[lastFish] = newFish;
        started = true;
    }

    public void OnPointerPress(Vector2 position)
    {
        int value;
        RythmFish rythmFish = fish[currentFish].GetComponent<RythmFish>();
        bool right = rythmFish.right;      
        if (position.x < Screen.width / 2 && !right)
        {
            value = checkDistance();
        }
        else if (position.x >= Screen.width / 2 && right)
        {
            value = checkDistance();
        }
        else
        {
            value = 0;
        }

        if (value == 0)
        {
            Debug.Log("MAL");
            textScript.showEvText(2);
            AudioManager.instance.PlaySound("FailFishTap");
            ResetCombo();
            stopRythmGame(true);
            return;
        }
        score += value;
        Destroy(fish[currentFish]);
        ++currentFish;
        if (currentFish >= size)
        {
            stopRythmGame(false);
        }
    }

    private int checkDistance()
    {
        float distance = Mathf.Abs(fish[currentFish].transform.position.x - bait.transform.position.x);
        if (distance <= 8.0f)
        {
            Debug.Log("EXCELENTE");
            textScript.showEvText(0);
            AudioManager.instance.PlaySound("CorrectFishTap");
            return 2;
        }
        else if (distance <= 24.0f)
        {
            Debug.Log("BIEN");
            textScript.showEvText(1);
            AudioManager.instance.PlaySound("CorrectFishTap2");
            return 1;
        }
        else
        {           
            return 0;
        }       
    }

    public void stopRythmGame(bool comboFailed)
    {
        started = false;
        panelRitmo.SetActive(false);
        isActive = false;
        for (int i = currentFish; i < fish.Length; ++i)
            Destroy(fish[i]);
        if (comboFailed) size = 0;
        if (bossFight)
        {
            bossManager.StopRythmGame(comboFailed, score);
        }
        else
        {
            BaitManager.StopRythmGame(comboFailed, score);
        }       
    }

    public void ResetSpeed()
    {
        speed = initSpeed;
    }

    public void ResetCombo()
    {
        score = 0;
        size = 0;
        speed = initSpeed;
    }

    


}
