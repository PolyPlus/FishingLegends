using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public bool atSurface;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (!atSurface)
        {
            MoveToSurface();
        }
        if(lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void MoveToSurface()
    {
        if (transform.position.y < 0.0f)
        {
            transform.position += new Vector3(0.0f, 2.0f, 0.0f) * Time.deltaTime;

        }
        else
        {
            atSurface = true;
        }
    }

    public void Hit()
    {
        // Play Sound
        Destroy(this.gameObject);
    }
}
