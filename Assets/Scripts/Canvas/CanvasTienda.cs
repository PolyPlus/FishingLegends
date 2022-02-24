using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTienda : MonoBehaviour
{
    public GameObject productos;
    public GameObject piscipedia;
    public GameObject clubPesca;
    // Start is called before the first frame update
    void Start()
    {
        piscipedia.SetActive(false);
        clubPesca.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Productos()
    {
        productos.SetActive(true);
        piscipedia.SetActive(false);
        clubPesca.SetActive(false);
    }
    public void Piscipedia()
    {
        piscipedia.SetActive(true);
        productos.SetActive(false);
        clubPesca.SetActive(false);
    }
    public void ClubPesca()
    {
        clubPesca.SetActive(true);
        productos.SetActive(false);
        piscipedia.SetActive(false);
    }
    public void exitButton()
    {
        Debug.Log("EXIT");
    }
}
