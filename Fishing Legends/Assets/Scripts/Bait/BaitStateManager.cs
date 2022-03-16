using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitStateManager : MonoBehaviour
{
    public Color32 color1;
    public Color32 color2;
    public RythmManager rythmGame;

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

    public void Bite(bool b)
    {
        animator.Play("Bite_Bait");
        if (b)
        {
            SwitchState(bittenState);
        }
        else if(currentState==bittenState) { 
            SwitchState(readyState); 
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
        SwitchState(boatState);
    }

    public void StartRythmGame()
    {
        Debug.Log("Start RythmGame");
        SwitchState(rythmState);
        rythmGame.startRythmGame();
    }

    public void StopRythmGame()
    {
        Debug.Log("Stop RythmGame");
        SwitchState(readyState);
    }
}
