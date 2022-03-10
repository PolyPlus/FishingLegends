using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public bool onWater;

    private Vector3 pos;
    private bool detected;
    

    public Vector3 Pos { get => pos; set => pos = value; }

    // Start is called before the first frame update
    void Start()
    {
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Detect()
    {
        if (!detected)
        {
            detected = true;
            return true;
        }
        return false;
    }

    public void Pull()
    {
        onWater = false;
    }
}
