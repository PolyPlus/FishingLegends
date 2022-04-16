using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Dialog: MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Sprite[] images;
    public GameObject fondo;
    public float textSpeed;
    private int index;
    public Image black;

    // private PointerControlls controlls;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(GameManager.GetInstance().Fade(black, false, textSpeed, ""));
        textComponent.text = string.Empty;
        startDialog();
        //controlls.Pointer.Press.started += _ => OnPointerPress();
    }


    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("PRESSED");
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }

    void startDialog()
    {
        index = 0;
        fondo.transform.GetComponent<Image>().sprite = images[index];
        StartCoroutine(TypeLine());


    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            if (index < images.Length)
                fondo.transform.GetComponent<Image>().sprite = images[index];
            StartCoroutine(TypeLine());
        }
        else
        {
            endDialog();
        }
    }
    void endDialog()
    {
        switch (StaticInfo.tutorialID)
        {
            case 1:
                if (PlayerPrefs.GetInt(StaticInfo.tutorialNavKey, 0) == 0)
                {
                    PlayerPrefs.SetInt(StaticInfo.tutorialNavKey, 1);
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.navigationScene));
                }
                else
                {                    
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt(StaticInfo.tutorialFishKey, 0) == 0)
                {
                    PlayerPrefs.SetInt(StaticInfo.tutorialFishKey, 1);
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, textSpeed, StaticInfo.fishingScene));
                }
                else
                {
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
                }                             
                break;
            case 3:
                if (PlayerPrefs.GetInt(StaticInfo.tutorialShopKey, 0) == 0)
                {
                    PlayerPrefs.SetInt(StaticInfo.tutorialShopKey, 1);
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, textSpeed, StaticInfo.shopScene));
                }
                else
                {
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
                }                             
                break;
            case 4:
                if (PlayerPrefs.GetInt(StaticInfo.tutorialLevKey, 0) == 0)
                {
                    PlayerPrefs.SetInt(StaticInfo.tutorialLevKey, 1);
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, textSpeed, StaticInfo.leviatanSecene));
                }
                else
                {
                    StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.startScene));
                }
                break;
        }
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }





}