using UnityEngine;

public class BaitBoatState : BaitBaseState
{
    public override void EnterState(BaitStateManager bait)
    {
        //Debug.Log("Entering Boat State");
    }
    public override void UpdateState(BaitStateManager bait)
    {

    }
    public override void OnCollisionEnter(BaitStateManager bait, Collision collision)
    {
        if (collision.gameObject.tag == "Water") bait.SwitchState(bait.readyState);
    }
    public override void OnPointerPress(BaitStateManager bait, Vector2 position)
    {
        bait.ThrowBait();
    }
}