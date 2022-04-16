using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Linq;

public class BossFightManager: MonoBehaviour
{
    public enum State
    {
        start,
        obstacle,
        rythm,
        end
    }

    public GameObject bossPrefab;

    public BoatMovement boatMovement;
    public RythmManager rythmGame;
    public WaterSpawner waterSpawner;
    public WaterMovement water1;
    public WaterMovement water2;
    public ObstacleSpawner obstacleSpawner;   
    public LureUI lureUI;

    // Animators
    public Animator baitAnimator;
    public Animator playerAnimator;
    public Animator bossAnimator;
    public Animator fishTransition;

    public bool exit;
    public State state;
    public int stage;

    private int numAnzuelos;
    private int score;
    [SerializeField] private float timeBetween = 4;
    private float timeNextStage;
    private PointerControlls controls;
    private FishData bossData;
    private bool waiting;

    public int Score { get => score; set => score = value; }
    public bool Waiting { get => waiting; set => waiting = value; }

    private void Awake()
    {       
        controls = new PointerControlls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        // Init values
        exit = false;
        Waiting = false;
        Score = 0;
        numAnzuelos = StaticInfo.numAnzuelos;
        state = State.start;
        stage = 1;       
        timeNextStage = timeBetween;
        lureUI.SetNumAnzuelos(numAnzuelos);

        // Controls
        controls.Pointer.Press.started += _ => OnPointerPress();
        controls.Pointer.Press.canceled += _ => OnPointerRelease();

        // References
        obstacleSpawner.bossFightManager = this;
        rythmGame.BossManager = this;
        rythmGame.bossFight = true;
        bossData = bossPrefab.GetComponent<FishData>();
    }

    private void Update()
    {
        if (Waiting)
        {
            timeNextStage -= Time.deltaTime;
            if(timeNextStage <= 0)
            {
                Waiting = false;
                timeNextStage = timeBetween;
                NextStage();
            }
        }
    }

    private void OnPointerPress()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();

        switch (state)
        {
            case State.start:
                if (!Waiting) StartBossFight();              
                break;
            case State.obstacle:
                boatMovement.OnPointerPress(mousePosition);
                break;
            case State.rythm:
                if (rythmGame.started)
                {
                    rythmGame.OnPointerPress(mousePosition);
                }               
                break;
            case State.end:
                if (exit)
                {
                    fishTransition.SetBool("reloadScene", true);
                }
                else
                {
                    StopBossFight();
                }                
                break;
        }
        //Debug.Log("Pointer Press on" + mousePosition);
    }

    private void OnPointerRelease()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        //Debug.Log("Pointer Release on" + mousePosition);
    }

    public void StartBossFight()
    {
        baitAnimator.Play("Throw_Boss");
        playerAnimator.Play("Throw");
        bossAnimator.Play("Start");
        AudioManager.instance.PlayDelayed("ThrowingRod", 0.5f);
        Waiting = true;
        AudioManager.instance.StartLoop("LeviatanIntro", "LeviatanLoop");
    }

    public void StopBossFight()
    {
        baitAnimator.Play("PullBack_Bait");
        playerAnimator.Play("Pull");       
        AudioManager.instance.PlaySound("ThrowingRod2");
        showFish();
    }

    public void NextStage()
    {
        switch (state)
        {
            case State.start:
                state = State.obstacle;
                waterSpawner.isActive = true;
                obstacleSpawner.StartSpawning(5 + 5*stage, 1.25f - 0.1f * stage);
                break;
            case State.obstacle:
                rythmGame.startRythmGame(4 * stage, 200 + 50 * stage);
                state = State.rythm;
                boatMovement.MoveToCenter();
                break;
            case State.rythm:
                if(stage > 3)
                {
                    waterSpawner.isActive = false;
                    bossAnimator.Play("Stop");
                    state = State.end;
                }
                else
                {
                    state = State.obstacle;
                    obstacleSpawner.StartSpawning(5 + 5 * stage, 1.25f - 0.25f * stage);
                }                
                break;
            case State.end:
                break;
        }
    }

    public void StopRythmGame(bool failed, int _score)
    {
        if (!failed)
        {
            stage++;           
            Score += _score * 10;
            UpdateScore(Score);
            Debug.Log("Score: " + Score);
        }
        else
        {
            UseLure();
        }
        NextStage();
    }

    public void UseLure()
    {
        if (numAnzuelos > 0) numAnzuelos--;
        lureUI.SetNumAnzuelos(numAnzuelos);
        StaticInfo.numAnzuelos = numAnzuelos;
        if (numAnzuelos <= 0)
        {
            fishTransition.SetBool("reloadScene", true);
        }
    }


    public void UpdateScore(int s)
    {
        StaticInfo.fishingScore += s;
    }

    public void showFish()
    {
        Destroy(bossAnimator.gameObject);
        AudioManager.instance.PlaySound("GetOutFish");
        AudioManager.instance.PlaySound("SmallVictory");
        Instantiate(bossPrefab);
        List<FishData> fishCaught = new List<FishData>();
        fishCaught.Add(bossData);
        if (StaticInfo.staticFishData == null)
        {
            StaticInfo.staticFishData = fishCaught.ToArray();
        }
        else
        {
            FishData[] aux = StaticInfo.staticFishData.Concat(fishCaught).ToArray();
            StaticInfo.staticFishData = aux;
        }
        exit = true;
    }

}

