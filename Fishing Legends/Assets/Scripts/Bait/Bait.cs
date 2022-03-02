using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{
    public bool onWater;
    public Color32 color1;
    public Color32 color2;

    private Vector3 pos;
    private bool detected;
    private bool isBiten;
    

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

    public void Bite(bool b)
    {
        isBiten = b;
        ChageColor();
    }

    public void ChageColor()
    {
        if (isBiten)
        {
            this.GetComponent<Renderer>().material.color = color2;
        }
        else
        {
            this.GetComponent<Renderer>().material.color = color1;
        }
    }

    public void Pull()
    {
        onWater = false;
    }
}
