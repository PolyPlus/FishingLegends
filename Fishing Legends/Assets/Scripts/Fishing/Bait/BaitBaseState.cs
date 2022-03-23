using UnityEngine;

public abstract class BaitBaseState
{
    public abstract void EnterState(BaitStateManager bait);
    public abstract void UpdateState(BaitStateManager bait);
    public abstract void OnCollisionEnter(BaitStateManager bait, Collision collision);
    public abstract void OnPointerPress(BaitStateManager bait, Vector2 position);
}
