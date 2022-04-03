using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasProductos : MonoBehaviour {

    int nivelBarco = StaticInfo.nivelBarco;
    int numAnzuelos = StaticInfo.maxAnzuelos;
    public Text textonivBarco;
    public Text textonumAnzuelos;
    public Button botonBarco;
    public Button botonAnzuelo;
    public CanvasTienda panelPrincipal;

    public GameObject textoFlotante;

    private int monedas;
    // Start is called before the first frame update
    void Start()
    {
        textonivBarco.text = "Nivel del barco:" + nivelBarco;
        textonumAnzuelos.text = "N�mero de anzuelos: " + numAnzuelos;
        monedas = PlayerPrefs.GetInt(StaticInfo.monedasKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void mejoraBarco()
    {
        if (nivelBarco < 3)
        {
            // Por ejemplo si mejora vale 1000 se hace monedas -= nivelBarco + nivelBarco*1000;
            int m = monedas - nivelBarco * 1000;
            if (m < 0)
            {
                Debug.Log("No se puede comprar.");
                MostrarTextoFlotante();
            }
            else
            {
                monedas = m;
                nivelBarco++;
                StaticInfo.nivelBarco = nivelBarco;
                PlayerPrefs.SetInt(StaticInfo.nivelBarcoKey, nivelBarco);
                PlayerPrefs.SetInt(StaticInfo.monedasKey, monedas);
            }
            textonivBarco.text = "Nivel del barco: " + nivelBarco;
            panelPrincipal.textoMonedas.text = "" + monedas;
        }
        else if (nivelBarco == 3)
        {
            botonBarco.interactable = false;
        }
    }

    public void mejoraAnzuelo()
    {

        if (numAnzuelos < 7)
        {
            // Por ejemplo si mejora vale 1000 se hace monedas -= numAnzuelos + numAnzuelos*1000;
            int m = monedas - numAnzuelos * 1000;
            if (m < 0)
            {
                Debug.Log("No se puede comprar.");
                MostrarTextoFlotante();
            }
            else
            {
                monedas = m;
                numAnzuelos++;
                StaticInfo.maxAnzuelos = numAnzuelos;
                PlayerPrefs.SetInt(StaticInfo.maxAnzuelosKey, numAnzuelos);
                PlayerPrefs.SetInt(StaticInfo.monedasKey, monedas);
            }
            textonumAnzuelos.text = "N�mero de anzuelos: " + numAnzuelos;
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
        GameObject texto = Instantiate(textoFlotante, panelPrincipal.transform);
    }

}
