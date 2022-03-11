using UnityEngine;

public class FishChaseState : FishBaseState
{
    private bool canBite;
    private float biteRange;
    private float moveSpeed;
    private Vector3 target;

    public override void EnterState(FishStateManager fish, BaitStateManager bait) 
    {
        Debug.Log("Entering Chase State");
        moveSpeed = fish.moveSpeed * 0.80f;
        biteRange = fish.biteRange;
        SetTarget(fish.transform.position, bait.Pos);
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if(bait.currentState == bait.boatState)
        {
            fish.Scape();
        }
        fish.FaceTarget(bait.Pos);
        if (canBite)
        {
            fish.SwitchState(fish.bitingState);
        }
        else
        {
            canBite = fish.MoveToTarget(target, moveSpeed);         
        }
    }

    private void SetTarget(Vector3 fishPos, Vector3 baitPos)
    {
        Vector3 dir = (fishPos - baitPos).normalized;
        Vector3 translate = dir * biteRange;
        target = baitPos + translate;
        Debug.Log("Distance: " + translate.magnitude);
    }
}
