using UnityEngine;

public class FishIdleState : FishBaseState
{
    public bool canSeeBait;
    public float moveSpeed = 1.0f;
    public float rotSpeed = 5f;
    public float movementRange = 3.0f;
    public float visionAngle = Mathf.PI / 6.0f;
    public float visionRange = 4.5f;

    private Vector3 initPos;
    private Vector3 target;    
    private float timeToMove;
    private bool isWaiting;

    public override void EnterState(FishStateManager fish) 
    {
        initPos = fish.transform.position;
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
                FaceTarget(fish.transform);
                MoveToTarget(fish.transform);
            }           
            CheckBait(fish.transform, bait);
        }
    }

    public override void OnCollisionEnter(FishStateManager fish, Collision collision) { }

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
        
        target = new Vector3(initPos.x + randomX, 0.0f, initPos.z + randomZ);
    }

    private void MoveToTarget(Transform transform)
    {
        if((target - transform.position).magnitude > moveSpeed)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        } else
        {
            isWaiting = true;
        }      
    }

    private void FaceTarget(Transform transform)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
    }
}
