using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitStateManager : MonoBehaviour
{
    public Color32 color1;
    public Color32 color2;
    public RythmManager rythmGame;
    public List<FishStateManager> fishList;
    public List<FishStateManager> fishCaught;

    // States
    public BaitBaseState currentState;
    public BaitBoatState boatState = new BaitBoatState();
    public BaitReadyState readyState = new BaitReadyState();
    public BaitDetectedState detectedState = new BaitDetectedState();
    public BaitBittenState bittenState = new BaitBittenState();
    public BaitRythmState rythmState = new BaitRythmState();

    private Vector3 pos;
    private Animator animator;

    public Vector3 Pos { get => pos; set => pos = value; }

    void Start()
    {
        Pos = transform.position;
        currentState = boatState;
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
        currentState.OnPointerPress(this, position);
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
            fishList.Add(fish);
        }
        else if(currentState==bittenState) { 
            SwitchState(readyState);
            fishList.Remove(fish);
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
    }

    public void PullBait()
    {
        animator.Play("PullBack_Bait");
        rythmGame.size = 0;
        rythmGame.ResetSpeed();
        SwitchState(boatState);
        GetFish();
    }

    public void StartRythmGame()
    {
        Debug.Log("Start RythmGame");
        SwitchState(rythmState);
        rythmGame.startRythmGame(GetTotalSize());
    }

    public void StopRythmGame(bool hasFailed)
    {
        Debug.Log("Stop RythmGame");
        if (hasFailed)
        {
            PullBait();
            fishList.Clear();
        }
        else
        {
            SwitchState(readyState);
        }
        
    }

    private void GetFish()
    {
        for(int i = 0; i < fishList.Count; i++)
        {
            //fishList[i].PlayCaughtAnimation();
            fishCaught.Add(fishList[i]);
        }
    }

    private int GetTotalSize()
    {
        int size = 0;
        for(int i = 0; i<fishList.Count; i++)
        {
            size += fishList[i].size;
        }
        return size;
    }
}
