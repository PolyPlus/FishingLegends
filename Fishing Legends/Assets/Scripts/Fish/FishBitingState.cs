using UnityEngine;

public class FishBitingState : FishBaseState
{
    public bool isBiting;
    public float baitRadius = 0.4f;    

    private float moveSpeed;
    private float biteRange;
    private float timeToAction;
    private bool isWaiting;
    private Vector3 target;

    public override void EnterState(FishStateManager fish, BaitStateManager bait) 
    {
        //Debug.Log("Entering Bite State");
        moveSpeed = fish.moveSpeed * 6.0f;
        biteRange = fish.biteRange;
        timeToAction = Random.Range(0.5f, 3.0f);
        isWaiting = true;
        SetTarget(fish.transform.position, bait.Pos);
    }
    public override void UpdateState(FishStateManager fish, BaitStateManager bait) 
    {
        if (bait.currentState == bait.boatState)
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
                MoveToBait(fish.transform, bait);
            } else
            {
                fish.MoveToTarget(target, moveSpeed);
            }
        }
    }

    private void SetTarget(Vector3 fishPos, Vector3 baitPos)
    {
        Vector3 dir = (fishPos - baitPos).normalized;
        Vector3 translate = dir * biteRange;
        target = baitPos + translate;
        Debug.Log("Distance: " + translate.magnitude);
    }

    public void MoveToBait(Transform transform, BaitStateManager bait)
    {
        Vector3 dir = (bait.Pos - transform.position);
        float distance = dir.magnitude;
        if(distance < baitRadius)
        {
            isWaiting = true;
            ChooseAction(bait);
        }
        else
        {
            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void ChooseAction(BaitStateManager bait)
    {
        int action = Random.Range(0, 2);
        if (action == 1)
        {
            isBiting = true;
            bait.Bite(true);
            Debug.Log("Bite!!");
        }
    }
}
