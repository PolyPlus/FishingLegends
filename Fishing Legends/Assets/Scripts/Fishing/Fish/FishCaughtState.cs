using UnityEngine;

public class FishCaughtState : FishBaseState
{
    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        Debug.Log("Entering Caught State");
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        
    }
}

