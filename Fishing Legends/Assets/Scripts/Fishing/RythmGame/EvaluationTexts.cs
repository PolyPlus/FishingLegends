using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationTexts : MonoBehaviour
{
    public Text ExcelenteText;
    public Text BienText;
    public Text MalText;

    // Start is called before the first frame update
    void Start()
    {
        HideEvaluationtext();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showEvText(int text)
    {
        switch (text)
        {
            case 0:
                StartCoroutine(showEvaluationText(ExcelenteText));
                break;
            case 1:
                StartCoroutine(showEvaluationText(BienText));
                break;
            case 2:
                StartCoroutine(showEvaluationText(MalText));
                break;
        }
    }

    private IEnumerator showEvaluationText(Text text)
    {
        Color c = text.color;
        c.a = 1;
        text.color = c;
        yield return new WaitForSeconds(0.2f);
        while (text.color.a > 0)
        {
            c = text.color;
            c.a = c.a - 0.02f;
            text.color = c;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void HideEvaluationtext()
    {
        Color c = ExcelenteText.color;
        c.a = 0;
        ExcelenteText.color = c;
        c = ExcelenteText.color;
        c.a = 0;
        ExcelenteText.color = c;
        c = ExcelenteText.color;
        c.a = 0;
        ExcelenteText.color = c;
    }
}
