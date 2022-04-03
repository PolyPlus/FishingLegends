using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInPageBehaviour : MonoBehaviour
{
    [SerializeField]
    private InputField username;
    [SerializeField]
    private InputField password;
    [SerializeField]
    private Canvas LogInCanvas;



    public void OnClickGoBack()
    {
        LogInCanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);       
    }
    public void OnClickSignIn()
    {
        Debug.Log("SignIn Pulsado" );

    }
}
