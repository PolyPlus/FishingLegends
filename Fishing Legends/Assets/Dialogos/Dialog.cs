using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Dialog : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // private PointerControlls controlls;

    // Start is called before the first frame update
    private void Start()
    {
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
        StartCoroutine(TypeLine());
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
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
