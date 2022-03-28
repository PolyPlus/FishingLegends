using UnityEngine;

public class FishIdleState : FishBaseState
{
    public bool canSeeBait;
    public float movementRange = 3.0f;
    public float visionAngle = Mathf.PI / 6.0f;
    public float visionRange = 4.5f;

    private float moveSpeed;
    private Vector3 initPos;
    private Vector3 target;    
    private float timeToMove;
    private bool isWaiting;

    public override void EnterState(FishStateManager fish, BaitStateManager bait) 
    {
        initPos = fish.transform.position;
        moveSpeed = fish.moveSpeed;
        timeToMove = Random.Range(2.0f, 6.0f);
        isWaiting = true;
        ResetTarget();
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait) 
    {
        if (canSeeBait)
        {
            fish.SwitchState(fish.chaseState);
        } else
        {        
            timeToMove -= Time.deltaTime;
            if(timeToMove <= 0)
            {
                ResetTarget();
                timeToMove = Random.Range(2.0f, 6.0f);
                isWaiting = false;
            }
            if (!isWaiting)
            {
                fish.FaceTarget(target);
                isWaiting = fish.MoveToTarget(target, moveSpeed);
            }           
            CheckBait(fish.transform, bait);
        }
    }

    private void CheckBait(Transform transform, BaitStateManager bait)
    {
        Vector3 direction = (bait.Pos - transform.position).normalized;
        float distance = (bait.Pos - transform.position).magnitude;
        float angle = Mathf.Acos(Vector3.Dot(direction, transform.forward));
        if (distance < visionRange && angle < visionAngle && bait.Detect())
        {
            Debug.Log("Angle: " + angle);
            canSeeBait = true;
        }
    }

    private void ResetTarget()
    {
        //Calculate random point in range
        float randomX = Random.Range(-movementRange, movementRange);
        float randomZ = Random.Range(-movementRange, movementRange);
        
        target = new Vector3(initPos.x + randomX, -1.0f, initPos.z + randomZ);
    }

}
