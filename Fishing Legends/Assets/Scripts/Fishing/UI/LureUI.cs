using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LureUI : MonoBehaviour
{
    public Text textAnzuelos;

    public void SetNumAnzuelos(int n)
    {
        textAnzuelos.text = "x " + n;
    }
}
