using UnityEngine;

public class FishBitingState : FishBaseState
{
    public float moveSpeed = 6.0f;
    public float scapeSpeed = 3.0f;
    public float baitRadius = 0.4f;
    public float biteRange = 1.5f;
    public bool isBiting;
    public float timeToLeave = 1.0f;

    private float timeToAction;
    private bool isWaiting;
    public override void EnterState(FishStateManager fish) 
    {
        Debug.Log("Entering Bite State");
        timeToAction = Random.Range(0.5f, 3.0f);
        isWaiting = true;
    }
    public override void UpdateState(FishStateManager fish, Bait bait) 
    {
        if (isBiting)
        {
            //Change to catching state?
            timeToLeave--;
            if(timeToLeave <= 0)
            {
                //Leave
            }
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
                MoveToBiteRange(fish.transform, bait);
            }
        }
    }
    public override void OnCollisionEnter(FishStateManager fish, Collision collision) { }

    public void MoveToBait(Transform transform, Bait bait)
    {
        Vector3 dir = (bait.Pos - transform.position);
        float distance = dir.magnitude;
        if(distance < baitRadius)
        {
            isWaiting = true;
            ChooseAction();
        }
        else
        {
            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void MoveToBiteRange(Transform transform, Bait bait)
    {
        Vector3 dir = (bait.Pos - transform.position);
        float distance = dir.magnitude;
        if (distance < biteRange)
        {
            transform.position -= dir.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void Bite()
    {
        isBiting = true;
        Debug.Log("Bite!!");
    }

    public void ChooseAction()
    {
        int action = Random.Range(0, 2);
        if (action == 1) Bite();
    }

    public void Scape(Transform transform)
    {
        Vector3 dir = new Vector3(0, -1, 0);
        transform.position += dir* scapeSpeed * Time.deltaTime;
    }
}
