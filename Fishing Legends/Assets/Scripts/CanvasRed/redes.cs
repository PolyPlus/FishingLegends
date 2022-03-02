using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void openTwitter()
    {
        Application.OpenURL("https://twitter.com/PolyplusStudios");
    }

    public void openYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCORDpONBjQlp1iaylG8L9uw");
    }

    public void openItchio()
    {
        Application.OpenURL("https://itch.io/profile/polyplus");
    }

    public void openPortfolio()
    {
        Application.OpenURL("https://polyplus.github.io/");
    }

    public void irAtras()
    {

    }
}