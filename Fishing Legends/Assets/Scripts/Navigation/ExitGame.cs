using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public GameObject exitpanel;
    public Animator transition;

    public void ShowPanel()
    {
        exitpanel.SetActive(true);
    }

    public void HidePanel()
    {
        exitpanel.SetActive(false);
    }

    public void salir()
    {
        GameManager.GetInstance().SelectScene(StaticInfo.startScene);
    }
}
