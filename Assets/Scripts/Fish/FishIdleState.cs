using UnityEngine;

public class FishIdleState : FishBaseState
{
    public bool canSeeBait;

    private Vector3 moveDir;
    private float moveDist;
    
    private float timeToMove;
    private float timeLastMove;

    public override void EnterState(FishStateManager fish) { }
    public override void UpdateState(FishStateManager fish) 
    {
        if (canSeeBait)
        {
            fish.SwitchState(fish.chaseState);
        } else
        {
            //Move Random
        }
    }

    public override void OnCollisionEnter(FishStateManager fish, Collision collision)
    {
        //If bait enters vision radius
        canSeeBait = true;
    }
}
