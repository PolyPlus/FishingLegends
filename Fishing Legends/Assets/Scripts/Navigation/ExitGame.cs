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
        AudioManager.instance.PlaySound("ButtonSelected");

        exitpanel.SetActive(true);
    }

    public void HidePanel()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        exitpanel.SetActive(false);
    }

    public void salir()
    {
        //GameManager.GetInstance().SelectScene(StaticInfo.startScene);
        AudioManager.instance.PlaySound("ButtonSelected");

        StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
    }
}
