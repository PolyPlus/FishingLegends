using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public GameObject exitpanel;
    public Animator transition;
    public Image black;

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
        //GameManager.GetInstance().SelectScene(StaticInfo.startScene);
        StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
    }
}
