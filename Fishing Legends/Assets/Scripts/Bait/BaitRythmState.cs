using UnityEngine;

public class BaitRythmState : BaitBaseState
{
    private float rythmTime;
    public override void EnterState(BaitStateManager bait)
    {
        Debug.Log("Entering rythm State");
        rythmTime = 1.0f;
        bait.ChageColor();
    }
    public override void UpdateState(BaitStateManager bait)
    {
        rythmTime -= Time.deltaTime;
        if(rythmTime <= 0)
        {            
            bait.SwitchState(bait.readyState);
            bait.ChageColor();
        }
    }
    public override void OnCollisionEnter(BaitStateManager bait, Collision collision)
    {

    }

    public override void OnPointerPress(BaitStateManager bait, Vector2 position)
    {
        //bait.StartRythmGame();
    }
}
