using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{    
    public float speed = -20;
    public WaterSpawner Spawner;
    public bool isActive;


    // Update is called once per frame
    void Update()
    {
        if (Spawner.isActive)
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            Spawner.Spawn();
            Destroy(this.gameObject);
        }
    }
}
