using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnMenu : MonoBehaviour
{
    public FishingManager fishingManager;
    public GameObject ReturnPanel;

    public void ShowPanel()
    {
        fishingManager.Paused = true;
        ReturnPanel.SetActive(true);
    }

    public void HidePanel()
    {
        fishingManager.Paused = false;
        ReturnPanel.SetActive(false);
    }

    public void ReturnToNavigation()
    {
        Debug.Log("Cambiar escena");
        GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
    }
}
