using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarResultados : MonoBehaviour
{
    public Text peces;
    public Text puntos;
    public ScrollRect sr;
    public GameObject[] listaPeces;
    public FishData[] fishDataList;
    public GameObject mostrarResultados;

    private bool pulsado = false;
    private bool salir = false;


    public void actualizarPuntuacion(FishData[] pecesTotales)
    {
        
        peces.text = "" + pecesTotales.Length;

        int puntuacion = 0;

        for(int i =0; i < pecesTotales.Length; i++)
        {
            puntuacion += pecesTotales[i].Points;
        }
        puntos.text = "" + puntuacion;
    }

    public void mostrarPeces(FishData[] pecesTotales)
    {
        fishDataList = pecesTotales;
        for (int i = 0; i < pecesTotales.Length; i++)
        {
            int id = pecesTotales[i].ID;
            GameObject pez = Instantiate(listaPeces[id]);
            pez.transform.SetParent(sr.content);
        }

    }

    public void onClick()
    {
        sr.gameObject.SetActive(false);
        mostrarResultados.SetActive(true);
        actualizarPuntuacion(fishDataList);
    }

    public void Salir()
    {
        mostrarResultados.SetActive(false);
    }
}
