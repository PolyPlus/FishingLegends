using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ReturnMenu : MonoBehaviour
{
    public BossFightManager bossManager;
    public FishingManager fishingManager;
    public GameObject ReturnPanel;
    public Animator fishTransition;


    public void ShowPanel()
    {
        AudioManager.instance.PlaySound("ButtonSelected");
        if (fishingManager != null)
        {
            fishingManager.Paused = true;
        }
        ReturnPanel.SetActive(true);
    }

    public void HidePanel()
    {
        AudioManager.instance.PlaySound("ButtonSelected");
        if (fishingManager != null)
        {
            fishingManager.Paused = false;
        }
        ReturnPanel.SetActive(false);
    }

    public void ReturnToNavigation()
    {
        AudioManager.instance.PlaySound("ButtonSelected");
        if (fishingManager != null)
        {
            if (fishingManager.FishCaught != null)
            {
                if (StaticInfo.staticFishData == null)
                {
                    StaticInfo.staticFishData = fishingManager.FishCaught;
                }
                else
                {
                    FishData[] d = StaticInfo.staticFishData.Concat(fishingManager.FishCaught).ToArray();
                    StaticInfo.staticFishData = d;
                }
                fishingManager.FishCaught = null;
            }
        }       
        fishTransition.SetBool("reloadScene", true);
        //GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
    }
}
