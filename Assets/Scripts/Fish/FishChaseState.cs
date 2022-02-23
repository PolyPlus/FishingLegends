using UnityEngine;

public class FishChaseState : FishBaseState
{
    public bool canBite;
    public override void EnterState(FishStateManager fish) { }
    public override void UpdateState(FishStateManager fish) 
    {
        if (canBite)
        {

        }
        //Go to the bait
    }
    public override void OnCollisionEnter(FishStateManager fish, Collision collision) 
    {
        //If bait enters biting radius
        canBite = true;
    }
}
