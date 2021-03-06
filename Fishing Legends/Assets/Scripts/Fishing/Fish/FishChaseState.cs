using UnityEngine;

public class FishChaseState : FishBaseState
{
    private bool canBite;
    private float biteRange;
    private float moveSpeed;
    private Vector3 target;

    public override void EnterState(FishStateManager fish, BaitStateManager bait) 
    {
        //Debug.Log("Entering Chase State");
        moveSpeed = fish.moveSpeed * 1.5f;
        biteRange = fish.baitDistance;
        SetTarget(fish.transform.position, bait.Pos);
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        fish.FaceTarget(bait.Pos);
        if (bait.currentState == bait.boatState)
        {
            fish.SwitchState(fish.scapeState);
        }     
        else if (canBite)
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
        target.y = fishPos.y;
    }
}
