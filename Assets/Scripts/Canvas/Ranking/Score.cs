using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Para guardar los datos
[Serializable]
public class Score 
{
    public string nombre;
    public float score;
    public Score(string nombre, float score)
    {
        this.nombre = nombre;
        this.score = score;
    }
}
