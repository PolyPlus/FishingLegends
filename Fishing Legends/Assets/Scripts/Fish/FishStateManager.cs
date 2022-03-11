using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateManager : MonoBehaviour
{
    public BaitStateManager bait;
    public float moveSpeed = 1.0f;
    public float scapeSpeed = 3.0f;
    public float rotSpeed = 5f;
    public float biteRange = 0.75f;

    // States
    public FishBaseState currentState;
    public FishIdleState idleState = new FishIdleState();
    public FishChaseState chaseState = new FishChaseState();
    public FishBitingState bitingState = new FishBitingState();
    private GameObject _gameObject;
    
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this, bait);
    }

    void FixedUpdate()
    {
        currentState.UpdateState(this, bait);
    }

    public void SwitchState(FishBaseState state)
    {
        currentState = state;
        currentState.EnterState(this, bait);
    }

    IEnumerator DestroyFishAfterTime()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public bool MoveToTarget(Vector3 target, float _moveSpeed)
    {
        if ((target - transform.position).magnitude > 0.06f)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * _moveSpeed * Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }

    public void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
    }

    public void Scape()
    {
        Vector3 dir = new Vector3(0, -1, 0);
        this.transform.position += dir * scapeSpeed * Time.deltaTime;
        StartCoroutine(DestroyFishAfterTime());
    }
}
