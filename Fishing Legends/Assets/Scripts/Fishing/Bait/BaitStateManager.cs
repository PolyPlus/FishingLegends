using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitStateManager : MonoBehaviour
{
    public Color32 color1;
    public Color32 color2;
    public Animator playerAnimator;
    private RythmManager rythmGame;
    public List<FishStateManager> fishCombo;
    public List<GameObject> fishPrefabs;
    public List<FishData> fishCaught;
    public int totalScore;
    public bool inCombo;

    // States
    public BaitBaseState currentState;
    public BaitBoatState boatState = new BaitBoatState();
    public BaitReadyState readyState = new BaitReadyState();
    public BaitDetectedState detectedState = new BaitDetectedState();
    public BaitBittenState bittenState = new BaitBittenState();
    public BaitRythmState rythmState = new BaitRythmState();
    public BaitCatchingState catchingState = new BaitCatchingState();

    private int comboScore;
    private Vector3 pos;
    private Animator animator;
    private GameObject currentFish;
    private FishingManager fishingManager;

    public Vector3 Pos { get => pos; set => pos = value; }
    public FishingManager FishingManager { get => fishingManager; set => fishingManager = value; }
    public RythmManager RythmGame { get => rythmGame; set => rythmGame = value; }

    void Start()
    {
        Pos = transform.position;
        currentState = boatState;
        inCombo = false;
        animator = this.GetComponent<Animator>();
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
        Pos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void OnPointerPress(Vector2 position)
    {
        if(!FishingManager.Paused)currentState.OnPointerPress(this, position);
    }

    public void SwitchState(BaitBaseState state)
    {
        currentState = state;
        state.EnterState(this);
        ChageColor();
    }

    public bool Detect()
    {
        if (currentState == readyState)
        {
            SwitchState(detectedState);
            return true;            
        }
        return false;
    }

    public void Bite(bool b, FishStateManager fish)
    {
        animator.Play("Bite_Bait");
        if (b)
        {
            SwitchState(bittenState);
            fishCombo.Add(fish);
        }
        else if(currentState==bittenState) { 
            SwitchState(readyState);
            fishCombo.Remove(fish);
        }
    }

    public void ChageColor()
    {
        if (currentState == rythmState)
        {
            this.GetComponent<Renderer>().material.color = color2;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = color1;
        }
    }

    public void ThrowBait()
    {
        animator.Play("Throw_Bait");
        playerAnimator.Play("Throw");
    }

    public void PullBait()
    {       
        RythmGame.ResetCombo();
        animator.Play("PullBack_Bait");
        playerAnimator.Play("Pull");
        if (fishCombo.Count > 0)
        {
            GetFish();
        } else
        {
            SwitchState(boatState);
        }           
    }

    public void StartRythmGame()
    {
        inCombo = true;
        SwitchState(rythmState);
        RythmGame.startRythmGame(GetTotalSize());
    }

    public void StopRythmGame(bool hasFailed, int score)
    {
        if (hasFailed)
        {
            inCombo = false;
            fishCombo.Clear();
            PullBait();           
        }
        else
        {
            comboScore += score * 10 * fishCombo.Count;
            Debug.Log("Combo Score: " + comboScore);
            SwitchState(readyState);
        }
        
    }

    public void showFish()
    {
        if(!inCombo)
        {
            RemovePrefab(0);
        }
        else
        {
            inCombo = false;
        }

        if(fishPrefabs.Count <= 0)
        {
            SwitchState(boatState);         
        }
        else
        {
            currentFish = Instantiate(fishPrefabs[0]);
        }       
    }

    private void GetFish()
    {
        Debug.Log("fish caught: " + fishCombo.Count);
        totalScore += comboScore;
        comboScore = 0;
        for (int i = 0; i < fishCombo.Count; i++)
        {
            fishPrefabs.Add(fishCombo[i].fishPrefab);
            fishCaught.Add(fishCombo[i].GetPrefabData());
            fishCombo[i].CatchFish();
        }
        Debug.Log("Total fish caught: " + fishCaught.Count);
        Debug.Log("Total Score: " + totalScore);
        fishCombo.Clear();
        SwitchState(catchingState);
    }

    private void RemovePrefab(int id)
    {
        Debug.Log("Remove prefab");
        fishPrefabs[id] = null;
        fishPrefabs.RemoveAt(id);
        Destroy(currentFish);
    }

    private int GetTotalSize()
    {
        int size = 0;
        for(int i = 0; i<fishCombo.Count; i++)
        {
            size += fishCombo[i].size;
        }
        return size;
    }
}
