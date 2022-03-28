using UnityEngine;

public class FishSpawnState : FishBaseState
{
    private bool isReady;
    private float moveSpeed;
    private Vector3 target;

    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        //Debug.Log("Entering Spawn State");
        moveSpeed = fish.moveSpeed;
        isReady = false;
        target = new Vector3(fish.transform.position.x, -1.0f, fish.transform.position.z);
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if (isReady)
        {
            fish.SwitchState(fish.idleState);
        }
        else
        {
            isReady = fish.MoveToTarget(target, moveSpeed);
        }
    }
}
