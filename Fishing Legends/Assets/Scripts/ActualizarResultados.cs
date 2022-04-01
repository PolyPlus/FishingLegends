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
    public FishData[] lista;
    public GameObject mostrarResultados;

    private bool pulsado = false;


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

    private void mostrarPeces(FishData[] pecesTotales)
    {
        for (int i = 0; i < pecesTotales.Length; i++)
        {
            int id = pecesTotales[i].ID;
            GameObject pez = Instantiate(listaPeces[id]);
            pez.transform.SetParent(sr.content);
        }

    }

    private void Start()
    {
        sr.gameObject.SetActive(true);
        mostrarPeces(lista);

        if (pulsado)
        {
            sr.gameObject.SetActive(false);
            mostrarResultados.SetActive(true);
            actualizarPuntuacion(lista);
        }
    }

    public void onClick()
    {
        pulsado = true; 
    }
}
