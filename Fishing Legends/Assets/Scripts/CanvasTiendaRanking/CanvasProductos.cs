using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasProductos : MonoBehaviour {

    
    public Text precioBarco;
    public Text precioAnzuelo;
    public Text textoNivBarco;
    public Text textoNumAnzuelos;
    public Button botonBarco;
    public Button botonAnzuelo;
    public CanvasTienda panelPrincipal;
    public GameObject textoFlotante;

    private int nivelBarco;
    private int numAnzuelos;
    private int monedas;
    // Start is called before the first frame update
    void Start()
    {
        nivelBarco = PlayerPrefs.GetInt(StaticInfo.nivelBarcoKey, 1);
        numAnzuelos = PlayerPrefs.GetInt(StaticInfo.maxAnzuelosKey, 3);
        monedas = PlayerPrefs.GetInt(StaticInfo.monedasKey, 0);
        textoNivBarco.text = "Nivel barco: " + nivelBarco;
        textoNumAnzuelos.text = "Nº anzuelos: " + numAnzuelos;
        precioBarco.text = "" + (nivelBarco * 1000);
        precioAnzuelo.text = "" + (numAnzuelos * 200);

        if (PlayerPrefs.GetInt(StaticInfo.maxAnzuelosKey, 3) == 7)
        {
            botonAnzuelo.interactable = false;
        }
        if (PlayerPrefs.GetInt(StaticInfo.nivelBarcoKey, 1) == 4)
        {
            botonBarco.interactable = false;
        }
    }

    public void mejoraBarco()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        if (nivelBarco < 4)
        {
            // Por ejemplo si mejora vale 1000 se hace monedas -= nivelBarco*1000;
            int m = monedas - nivelBarco * 1000;
            if (m < 0)
            {
                Debug.Log("No hay suficientes monedas.");
                MostrarTextoFlotante();
            }
            else
            {
                monedas = m;
                nivelBarco++;
                StaticInfo.nivelBarco = nivelBarco;
                PlayerPrefs.SetInt(StaticInfo.nivelBarcoKey, nivelBarco);
                PlayerPrefs.SetInt(StaticInfo.monedasKey, monedas);

                if (PlayerPrefs.GetInt(StaticInfo.nivelBarcoKey, 1) == 3)
                {
                    botonBarco.interactable = false;
                }
            }
            textoNivBarco.text = "Nivel barco: " + nivelBarco;
            precioBarco.text = "" + (nivelBarco * 1000);
            panelPrincipal.textoMonedas.text = "" + monedas;
        }
        else if (nivelBarco == 4)
        {
            botonBarco.interactable = false;
        }
    }

    public void mejoraAnzuelo()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        if (numAnzuelos < 7)
        {
            // Por ejemplo si mejora vale 1000 se hace monedas -= numAnzuelos*1000;
            int m = monedas - numAnzuelos * 200;
            if (m < 0)
            {
                Debug.Log("No hay suficientes monedas.");
                MostrarTextoFlotante();
            }
            else
            {
                monedas = m;
                numAnzuelos++;
                StaticInfo.maxAnzuelos = numAnzuelos;
                PlayerPrefs.SetInt(StaticInfo.maxAnzuelosKey, numAnzuelos);
                PlayerPrefs.SetInt(StaticInfo.monedasKey, monedas);

                if (PlayerPrefs.GetInt(StaticInfo.maxAnzuelosKey, 3) == 7)
                {
                    botonAnzuelo.interactable = false;
                }
            }
            textoNumAnzuelos.text = "Nº anzuelos: " + numAnzuelos;          
            precioAnzuelo.text = "" + (numAnzuelos * 200);
            panelPrincipal.textoMonedas.text = "" + monedas;
        }
        else if (numAnzuelos == 7)
        {
            botonAnzuelo.interactable = false;
        }
    }

    public void CeboNormal()
    {
        Debug.Log("Boton Cebo Normal Pulsado");
    }

    public void CeboGourmet()
    {
        Debug.Log("Boton Cebo Gourmet Pulsado");
    }

    public void MostrarTextoFlotante()
    {
        GameObject texto = Instantiate(textoFlotante, transform);
    }

}
