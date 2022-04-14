using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTienda : MonoBehaviour
{
    public GameObject productos;
    public GameObject piscipedia;
    public GameObject clubPesca;
    public GameObject panelPrincipal;
    public GameObject canvasBotonesAjustes;
    public Text textoMonedas;
    public Animator fishTransition;

    // Start is called before the first frame update
    void Start()
    {
        panelPrincipal.SetActive(true);
        productos.SetActive(true);
        piscipedia.SetActive(false);
        clubPesca.SetActive(false);
        textoMonedas.text = "" + PlayerPrefs.GetInt(StaticInfo.monedasKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Productos()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        productos.SetActive(true);
        piscipedia.SetActive(false);
        clubPesca.SetActive(false);
    }
    public void Piscipedia()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        piscipedia.SetActive(true);
        productos.SetActive(false);
        clubPesca.SetActive(false);
    }
    public void ClubPesca()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        clubPesca.SetActive(true);
        productos.SetActive(false);
        piscipedia.SetActive(false);
    }
    public void exitButton()
    {
        /*Debug.Log("EXIT");
        panelPrincipal.SetActive(false);
        productos.SetActive(false);
        piscipedia.SetActive(false);
        clubPesca.SetActive(false);
        canvasBotonesAjustes.SetActive(true); */

        AudioManager.instance.PlaySound("ButtonSelected");

        fishTransition.SetBool("reloadScene", true);
        //GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
    }
}
