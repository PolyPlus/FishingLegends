using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject navegacion, pesca, tienda;

    void Start()
    {
        switch (StaticInfo.tutorialID)
        {
            case 1:
                navegacion.SetActive(true);
                break;
            case 2:
                pesca.SetActive(true);
                break;
            case 3:
                tienda.SetActive(true);
                break;
        }
    }

}
