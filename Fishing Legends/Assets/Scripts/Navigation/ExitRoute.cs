using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoute : MonoBehaviour
{
    public GameObject exitRoutepanel;
    public Animator transition;

    public void ShowPanel()
    {
        exitRoutepanel.SetActive(true);
    }

    public void HidePanel()
    {
        exitRoutepanel.SetActive(false);
    }

    public void salir()
    {
        StaticInfo.finishRoute = true;
        transition.SetBool("reloadScene", true);
    }

}
