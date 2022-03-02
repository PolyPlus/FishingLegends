using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInPageBehaviour : MonoBehaviour
{
    [SerializeField]
    private InputField username;
    [SerializeField]
    private InputField password;
    [SerializeField]
    private Canvas SignInCanvas;

    public void OnClickLogIn()
    {
        Debug.Log("LogIn Pulsado");
        Debug.Log("user: " + username.text + " pass: " + password.text);
    }
    public void OnClickSignIn()
    {
        Debug.Log("SignIn Pulsado");
        SignInCanvas.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void OnClickContact()
    {
        Debug.Log("Contact Pulsado");
    }
    public void OnClickConfiguration()
    {
        Debug.Log("Opciones Pulsado");
    }
}
