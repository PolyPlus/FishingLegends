using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BaitStateManager : MonoBehaviour
{

    // Public
    public Animator playerAnimator;
    public Animator fishTransition;
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

    // Private
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
        if(FishingManager!= null)
        {
            if (!FishingManager.Paused)
            {
                currentState.OnPointerPress(this, position);
            }
        }
        else
        {
            currentState.OnPointerPress(this, position);
        }      
    }

    public void SwitchState(BaitBaseState state)
    {
        currentState = state;
        state.EnterState(this);
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

    public void ThrowBait()
    {
        if (fishingManager.exit)
        {
            if (StaticInfo.staticFishData == null)
            {
                StaticInfo.staticFishData = fishingManager.FishCaught;
            }
            else
            {
                FishData[] d = StaticInfo.staticFishData.Concat(fishingManager.FishCaught).ToArray();
                StaticInfo.staticFishData = d;
            }
            fishTransition.SetBool("reloadScene", true);
            fishingManager.exit = false;
        } else
        {
            animator.Play("Throw_Bait");
            playerAnimator.Play("Throw");
            AudioManager.instance.PlayDelayed("ThrowingRod", 0.5f);
        }      
    }

    public void PullBait()
    {       
        RythmGame.ResetCombo();
        animator.Play("PullBack_Bait");
        playerAnimator.Play("Pull");
        AudioManager.instance.PlaySound("ThrowingRod2");
        if (fishCombo.Count > 0)
        {
            GetFish();
            fishingManager.UseLure();
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
            AudioManager.instance.PlaySound("SmallVictory");
            currentFish = Instantiate(fishPrefabs[0]);
        }       
    }

    private void GetFish()
    {
        Debug.Log("fish caught: " + fishCombo.Count);
        AudioManager.instance.PlaySound("GetOutFish");
        fishingManager.UpdateScore(comboScore);
        
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
        fishingManager.UpdateFishData(fishCaught.ToArray());
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
