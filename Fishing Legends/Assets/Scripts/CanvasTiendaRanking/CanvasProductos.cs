using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasProductos : MonoBehaviour {

    int nivelBarco = 1;
    int numAnzuelos = 3;
    public Text textonivBarco;
    public Text textonumAnzuelos;
    public Button botonBarco;
    public Button botonAnzuelo;
    public CanvasTienda panelPrincipal;

    // Start is called before the first frame update
    void Start()
    {
        textonivBarco.text = "Nivel del barco:" + nivelBarco;
        textonumAnzuelos.text = "Número de anzuelos: " + numAnzuelos;
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
            int m = panelPrincipal.monedas - nivelBarco * 1000;
            if (m < 0)
            {
                Debug.Log("No se puede comprar.");
            }
            else
            {
                panelPrincipal.monedas = m;
                nivelBarco++;
            }
            textonivBarco.text = "Nivel del barco: " + nivelBarco;
            panelPrincipal.textoMonedas.text = "Monedas: " + panelPrincipal.monedas;
        }
        else if (nivelBarco == 3)
        {
            botonBarco.interactable = false;
        }
    }

    public void mejoraAnzuelo()
    {

        if (numAnzuelos < 5)
        {
            // Por ejemplo si mejora vale 1000 se hace monedas -= numAnzuelos + numAnzuelos*1000;
            int m = panelPrincipal.monedas - numAnzuelos * 1000;
            if (m < 0)
            {
                Debug.Log("No se puede comprar.");
            }
            else
            {
                panelPrincipal.monedas = m;
                numAnzuelos++;
            }
            textonumAnzuelos.text = "Número de anzuelos: " + numAnzuelos;
        }
        else if (numAnzuelos == 5)
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

}
