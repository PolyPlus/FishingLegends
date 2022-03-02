using UnityEngine;

public abstract class FishBaseState 
{
    public abstract void EnterState(FishStateManager fish);
    public abstract void UpdateState(FishStateManager fish, Bait bait);
    public abstract void OnCollisionEnter(FishStateManager fish, Collision collision);
}
