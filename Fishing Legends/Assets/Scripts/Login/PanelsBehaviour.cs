using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelsBehaviour : MonoBehaviour
{

    #region Canvas
    [SerializeField]
    private Canvas LogInCanvas;
    [SerializeField]
    private Canvas SignInCanvas;
    [SerializeField]
    private Canvas ConfigCanvas;
    [SerializeField]
    private Canvas SoundConfigCanvas;
    [SerializeField]
    private Canvas ContactCanvas;
    #endregion

    #region LogIn Elements
    [SerializeField]
    private InputField usernameL;
    [SerializeField]
    private InputField passwordL;
    #endregion

    #region SignIn Elements
    [SerializeField]
    private InputField usernameS;
    [SerializeField]
    private InputField passwordS;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
        }
    }

    public void OnClickLogIn()
    {
        Debug.Log("LogIn Pulsado");
        if (usernameL.text != "" && passwordL.text != "")
        {
            Debug.Log("user: " + usernameL.text + " pass: " + passwordL.text);
            GameManager.GetInstance().SelectScene("ShopScene");                  //Cambiar nombre a escena definitiva
        }
    }
    public void OnClickSignIn()
    {
        Debug.Log("SignIn Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(true);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
    }
    public void OnClickContact()
    {
        Debug.Log("Contact Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(true);
    }
    public void OnClickConfiguration()
    {
        Debug.Log("Opciones Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(true);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
    }

    [System.Obsolete]
    public void OnClickGoBack()
    {
        if(ConfigCanvas.gameObject.active == true || SignInCanvas.gameObject.active == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
        }
        else if (SoundConfigCanvas.gameObject.active == true)
        {
            LogInCanvas.gameObject.SetActive(false);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(true);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
        }
        else if (ContactCanvas.gameObject.active == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
        }
    }
    public void OnClickSoundConfig()
    {
        Debug.Log("Opciones Sonido Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(true);
        ContactCanvas.gameObject.SetActive(false);
    }
}
