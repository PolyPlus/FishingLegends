using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAjustesJugar : MonoBehaviour
{
    public GameObject canvasBotonesAjustes;
    public GameObject canvasTienda;
    // Start is called before the first frame update
    void Start()
    {
        canvasBotonesAjustes.SetActive(true);
    }

    public void Ajustes()
    {
        canvasTienda.SetActive(true);
        canvasBotonesAjustes.SetActive(false);
    }

    public void Jugar()
    {
        Debug.Log("Botón jugar pulsado");
        GameManager.GetInstance().SelectScene("FishingScene");                 
    } 

}
