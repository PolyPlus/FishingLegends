using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogOldManStory : MonoBehaviour, IPointerClickHandler
{ 
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    public Sprite OldManHappy;
    public Sprite OldManGrumpy;
    public Image OldMan;

    public Image black;

    // private PointerControlls controlls;

    // Start is called before the first frame update
    private void Start()
    {
        textComponent.text = string.Empty;
        StartCoroutine(GameManager.GetInstance().Fade(black, false, textSpeed, ""));
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
        StartCoroutine(TypeLine());
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            ChangeExpression();
            StartCoroutine(TypeLine());
        }
        else
        {
            StaticInfo.tutorialID = 1;
            PlayerPrefs.SetInt(StaticInfo.tutorialKey, 1);
            StartCoroutine(GameManager.GetInstance().Fade(black, true, textSpeed, StaticInfo.tutorialScene));
            //gameObject.SetActive(false);
        }
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void ChangeExpression()
    {
        if (index == 7)
            OldMan.sprite = OldManHappy;
    }

}
