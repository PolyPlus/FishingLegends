using UnityEngine;

public class FishBitingState : FishBaseState
{
    public bool isBiting;
  
    private float moveSpeed;
    private float biteRange;
    private float baitDistance;
    private float timeToAction;
    private bool isWaiting;
    private Vector3 target;
    private Vector3 bitePos;

    public override void EnterState(FishStateManager fish, BaitStateManager bait)
    {
        //Debug.Log("Entering Bite State");
        moveSpeed = fish.moveSpeed * 6.0f;
        biteRange = fish.biteRange;
        baitDistance = fish.baitDistance;
        timeToAction = Random.Range(0.5f, 3.0f);
        isWaiting = true;
        SetTarget(fish.transform.position, bait.Pos);
        SetBitePos(fish.transform.position, bait.Pos);
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait)
    {
        if (bait.currentState == bait.boatState || bait.currentState == bait.catchingState)
        {
            fish.SwitchState(fish.scapeState);
        }
        else if (isBiting)
        {
            fish.SwitchState(fish.comboState);
        }
        else
        {
            timeToAction -= Time.deltaTime;
            if (timeToAction <= 0)
            {
                timeToAction = Random.Range(2.0f, 6.0f);
                isWaiting = false;
            }
            if (!isWaiting)
            {
                isWaiting = fish.MoveToTarget(bitePos, moveSpeed);
                if (isWaiting) ChooseAction(fish, bait);
            }
            else
            {
                fish.MoveToTarget(target, moveSpeed);
            }
        }
    }

    private void SetTarget(Vector3 fishPos, Vector3 baitPos)
    {
        Vector3 dir = (fishPos - baitPos).normalized;
        Vector3 translate = dir * baitDistance;
        target = baitPos + translate;
        target.y = fishPos.y;
    }

    private void SetBitePos(Vector3 fishPos, Vector3 baitPos)
    {
        Vector3 dir = (fishPos - baitPos).normalized;
        Vector3 translate = dir * biteRange;
        bitePos = baitPos + translate;
        bitePos.y = fishPos.y;
    }

    public void ChooseAction(FishStateManager fish, BaitStateManager bait)
    {
        int action = Random.Range(0, 3);
        if (action < 2)
        {
            isBiting = true;
            AudioManager.instance.PlaySound("Splash");
            bait.Bite(true, fish);
        } else
        {
            AudioManager.instance.PlaySound("SoftBite");
        }       
    }
}
