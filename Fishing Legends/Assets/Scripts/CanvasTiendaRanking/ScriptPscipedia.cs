using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptPscipedia : MonoBehaviour
{
    public Sprite newImage;
    public bool change = false;
    public int fishID=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            transform.GetChild(fishID).GetComponent<Image>().sprite = newImage;
            //switch (fishID) 
            //{
            //    case 1:
            //        transform.GetChild(0).GetComponent<Image>().sprite = newImage;
            //        break;
            //    case 2:
            //        transform.GetChild(1).GetComponent<Image>().sprite = newImage;
            //        break;
            //    default:
            //        break;
            //} 


            //  GetComponent<Image>().sprite = newImage;
        }
    }
    void changeImage()
    {
        if(change)
        GetComponent<Image>().sprite=newImage;
    }
}
