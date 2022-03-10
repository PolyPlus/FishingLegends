using UnityEngine;

public class FishChaseState : FishBaseState
{
    public float moveSpeed = 0.5f;
    public float rotSpeed = 5.0f;

    public bool canBite;
    public float biteRange = 1.5f;

    public override void EnterState(FishStateManager fish) 
    {
        Debug.Log("Entering Chase State");
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if(bait.currentState == bait.boatState)
        {
            fish.Scape();
        }
        FaceBait(fish.transform, bait);
        if (canBite)
        {
            fish.SwitchState(fish.bitingState);
        }
        else
        {
            MoveToBait(fish.transform, bait);
        }
        //Go to the bait
    }

    private void FaceBait(Transform transform, BaitStateManager bait)
    {
        Vector3 direction = (bait.Pos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
    }

    public void MoveToBait(Transform transform, BaitStateManager bait)
    {
        Vector3 dir = (bait.Pos - transform.position);
        float distance = dir.magnitude;
        if(distance > biteRange + 0.01)
        {
            transform.position += dir * moveSpeed * Time.deltaTime;
        } 
        else if(distance < biteRange - 0.01)
        {
            transform.position -= dir * moveSpeed * Time.deltaTime;
        }
        else
        {
            canBite = true;
            Debug.Log(distance);
        }
    }
    public override void OnCollisionEnter(FishStateManager fish, Collision collision) 
    {
        //If bait enters biting radius
        canBite = true;
    }


}
