using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ActualizarResultados : MonoBehaviour
{
    private ScoreData sd;

    public Text peces;
    public Text puntos;
    public Text monedas;
    public ScrollRect sr;
    public GameObject mostrarPecesPanel;
    public GameObject[] listaPeces;
    public FishData[] fishDataList;
    public GameObject mostrarResultados;
    public Animator fishTransition;

    //private bool pulsado = false;
    //private bool salir = false;

    private void Start()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

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

        sd.scores.Add(new Score(PlayerPrefs.GetString(StaticInfo.name), StaticInfo.totalScore));

        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
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
        monedas.text = "" + m;
        StaticInfo.monedas = m;
        PlayerPrefs.SetInt(StaticInfo.monedasKey, m + PlayerPrefs.GetInt(StaticInfo.monedasKey, 0));        
    }

    public void onClick()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        //sr.gameObject.SetActive(false);
        mostrarPecesPanel.SetActive(false);
        mostrarResultados.SetActive(true);
        actualizarPuntuacion(fishDataList);
        actualizarMonedas();
    }

    public void Salir()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        mostrarResultados.SetActive(false);
        fishTransition.SetBool("reloadScene",true);
        //GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
    }
}
