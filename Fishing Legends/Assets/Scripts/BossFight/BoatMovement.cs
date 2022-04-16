using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed;
    public Vector3 target;
    public BossFightManager bossFightManager;

    private int pos;
    private bool atTarget;
    private Vector3 startPosition;

    private void Awake()
    {
        gameObject.GetComponent<Renderer>().material.renderQueue = 1998;
    }

    private void Start()
    {
        pos = 1;
        atTarget = true;
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
    
    }

    private void Update()
    {
        if (!atTarget)
        {
            MoveToTarget();
        }   
    }

    public void OnPointerPress(Vector2 position)
    {
        if(position.x < Screen.width/2 && pos > 0)
        {
            pos--;           
            SetTarget();
            Debug.Log("Move Left");
        }
        else if(position.x >= Screen.width / 2 && pos < 2)
        {
            pos++;
            SetTarget();
            Debug.Log("Move Right");
        }
    }

    public void SetTarget()
    {
        atTarget = false;
        switch (pos)
        {
            case 0:
                target = startPosition + new Vector3(-5.0f, 0.0f, 0.0f);
                break;
            case 1:
                target = startPosition;
                break;
            case 2:
                target = startPosition + new Vector3(5.0f, 0.0f, 0.0f);
                break;
        }
    }

    public void MoveToTarget()
    {
        if ((target - transform.position).magnitude > 0.2f)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

        }
        else
        {
            atTarget = true;
        }
    }

    public void MoveToCenter()
    {
        pos = 1;
        SetTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            other.GetComponent<ObstacleMovement>().Hit();
            Debug.Log("Golpe");
            bossFightManager.UseLure();
        }
    }
}
