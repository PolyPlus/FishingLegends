using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateManager : MonoBehaviour
{
    public BaitStateManager bait;
    public float scapeSpeed = 3.0f;

    // States
    public FishBaseState currentState;
    public FishIdleState idleState = new FishIdleState();
    public FishChaseState chaseState = new FishChaseState();
    public FishBitingState bitingState = new FishBitingState();
    private GameObject _gameObject;
    
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    void FixedUpdate()
    {
        currentState.UpdateState(this, bait);
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

    IEnumerator DestroyFishAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void Scape()
    {
        Vector3 dir = new Vector3(0, -1, 0);
        this.transform.position += dir * scapeSpeed * Time.deltaTime;
        StartCoroutine(DestroyFishAfterTime());
    }
}
