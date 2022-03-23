using UnityEngine;

public class FishComboState : FishBaseState
{
    public bool isCaught;
    public float timeToScape;

    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        //Debug.Log("Entering Combo State");
        isCaught = false;
        timeToScape = 0.5f;
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if (!isCaught)
        {
            if (bait.currentState == bait.boatState)
            {
                fish.SwitchState(fish.scapeState);
            }
            else if (bait.currentState == bait.rythmState)
            {
                isCaught = true;
            }
            else
            {
                timeToScape -= Time.deltaTime;
                if (timeToScape <= 0)
                {
                    bait.Bite(false);
                    fish.SwitchState(fish.scapeState);
                }
            }
        } 
        else
        {
            if (bait.currentState == bait.boatState)
            {
                Debug.Log("Fish Caught!");
                fish.SwitchState(fish.scapeState);
            }
        }
        
    }
}
