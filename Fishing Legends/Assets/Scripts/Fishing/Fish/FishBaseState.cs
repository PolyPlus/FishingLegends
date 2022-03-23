using UnityEngine;

public abstract class FishBaseState 
{
    public abstract void EnterState(FishStateManager fish, BaitStateManager bait);
    public abstract void UpdateState(FishStateManager fish, BaitStateManager bait);
}
