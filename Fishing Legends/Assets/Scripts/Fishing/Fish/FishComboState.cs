using UnityEngine;

public class FishComboState : FishBaseState
{
    public bool isPulling;
    public float timeToScape;

    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        //Debug.Log("Entering Combo State");
        isPulling = false;
        timeToScape = 0.5f;
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if (!isPulling)
        {
            if (bait.currentState == bait.boatState)
            {
                fish.SwitchState(fish.scapeState);
            }
            else if (bait.currentState == bait.rythmState)
            {
                isPulling = true;
            }
            else
            {
                timeToScape -= Time.deltaTime;
                if (timeToScape <= 0)
                {
                    bait.Bite(false, fish);
                    fish.SwitchState(fish.scapeState);
                }
            }
        } 
        else
        {
            if (bait.currentState == bait.boatState && !bait.inCombo)
            {
                fish.SwitchState(fish.scapeState);
            }
        }
        
    }
}
