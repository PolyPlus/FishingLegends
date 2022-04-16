using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RouteArrow : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    // Start is called before the first frame update
    public bool pointerOver;
    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HE ENTRADO");
        pointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("HE SALIDO");
        pointerOver = false;
    }
}
