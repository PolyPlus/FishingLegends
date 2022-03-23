using UnityEngine;

public class FishScapeState : FishBaseState
{
    private float moveSpeed;
    private float distance;
    private Vector3 target;
    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        //Debug.Log("Entering Scape State");
        moveSpeed = fish.moveSpeed * 3.0f;
        distance = 10.0f;
        SetTarget(fish.transform.position, bait.Pos);
        fish.Scape();
    }

    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        fish.FaceTarget(target);
        fish.MoveToTarget(target, moveSpeed);
    }

    private void SetTarget(Vector3 fishPos, Vector3 baitPos)
    {
        Vector3 dir = (fishPos - baitPos).normalized;
        target = baitPos + dir * distance;
    }
}

