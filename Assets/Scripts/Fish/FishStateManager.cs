using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateManager : MonoBehaviour
{
    private FishBaseState currentState;
    public FishIdleState idleState = new FishIdleState();
    public FishChaseState chaseState = new FishChaseState();
    public FishBitingState bitingState = new FishBitingState();
    public GameObject _gameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(FishBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
