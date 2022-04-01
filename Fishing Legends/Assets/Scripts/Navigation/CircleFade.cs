using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleFade : MonoBehaviour
{
    public bool isActive = true;

    public bool isStarting = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        isStarting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (isStarting)
            {   if(transform.localScale.x <= 100)
                {

                    transform.localScale += new Vector3(100, 100, 100) * Time.deltaTime;
                    //transform.Rotate(new Vector3(0, 0, 75 * Time.deltaTime));
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
            else
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale -= new Vector3(100, 100, 100)*Time.deltaTime;
                    //transform.Rotate(new Vector3(0, 0, 75* Time.deltaTime));
                }
                else
                {
                    //isActive = false;
                    transform.localScale = new Vector3(0, 0, 0);
                    SceneManager.LoadScene("FishingScene");
                }
                    
            }
            
        }
    }
}
