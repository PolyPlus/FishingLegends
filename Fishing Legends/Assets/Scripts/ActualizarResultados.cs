using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarResultados : MonoBehaviour
{
    public Text peces;
    public Text puntos;

    public void ActualizarPuntuacion(FishData[] pecesTotales)
    {
        peces.text = "" + pecesTotales.Length;

        int puntuacion = 0;
        for(int i =0; i < pecesTotales.Length; i++)
        {
            puntuacion += pecesTotales[i].Points;
        }
        puntos.text = "" + puntuacion;
    }

}
