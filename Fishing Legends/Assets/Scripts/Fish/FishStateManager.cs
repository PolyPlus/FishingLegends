using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStateManager : MonoBehaviour
{
    public BaitStateManager bait;
    
    public float moveSpeed = 1.0f;
    public float rotSpeed = 5f;
    public float biteRange = 1.5f;

    // States
    public FishBaseState currentState;
    public FishIdleState idleState = new FishIdleState();
    public FishChaseState chaseState = new FishChaseState();
    public FishBitingState bitingState = new FishBitingState();
    public FishScapeState scapeState = new FishScapeState();
    public FishComboState comboState = new FishComboState();
    public Animator animator;

    void Start()
    {
<<<<<<< Updated upstream:Fishing Legends/Assets/Scripts/Fish/FishStateManager.cs
        currentState = idleState;
=======
        animator = GetComponentInChildren<Animator>();
        currentState = spawnState;
>>>>>>> Stashed changes:Fishing Legends/Assets/Scripts/Fishing/Fish/FishStateManager.cs
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
            animator.SetFloat("Speed", _moveSpeed * 2);
            return false;
        }
        else
        {
            animator.SetFloat("Speed", moveSpeed);
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
        //Vector3 dir = new Vector3(0, -1, 0);
        //this.transform.position += dir * scapeSpeed * Time.deltaTime;
        StartCoroutine(DestroyFishAfterTime());
    }
}