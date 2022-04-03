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
    public Animator fishTransition;

    private bool pulsado = false;
    private bool salir = false;


    public void actualizarPuntuacion(FishData[] pecesTotales)
    {
        
        peces.text = "" + pecesTotales.Length;

        int puntuacion = 0;

        if (pecesTotales != null)
        {
            for (int i = 0; i < pecesTotales.Length; i++)
            {
                puntuacion += pecesTotales[i].Points;
            }
        } 

        puntuacion += StaticInfo.fishingScore;
        puntos.text = "" + puntuacion;
        StaticInfo.totalScore = puntuacion;

        StaticInfo.addRanking = true;
    }

    public void mostrarPeces(FishData[] pecesTotales)
    {
        if (pecesTotales != null)
        {
            fishDataList = pecesTotales;
            for (int i = 0; i < pecesTotales.Length; i++)
            {
                int id = pecesTotales[i].ID;
                PlayerPrefs.SetInt(StaticInfo.fishKeys[id], 1);
                //StaticInfo.piscipedia[id] = true;
                GameObject pez = Instantiate(listaPeces[id]);
                pez.transform.SetParent(sr.content);
            }
        }

    }

    public void actualizarMonedas()
    {
        int m = StaticInfo.totalScore / 2;
        StaticInfo.monedas = m;
        PlayerPrefs.SetInt(StaticInfo.monedasKey, m + PlayerPrefs.GetInt(StaticInfo.monedasKey, 0));
    }

    public void onClick()
    {
        sr.gameObject.SetActive(false);
        mostrarResultados.SetActive(true);
        actualizarPuntuacion(fishDataList);
        actualizarMonedas();
    }

    public void Salir()
    {
        mostrarResultados.SetActive(false);
        fishTransition.SetBool("reloadScene",true);
        //GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
    }
}
