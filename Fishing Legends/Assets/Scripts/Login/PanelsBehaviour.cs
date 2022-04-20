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
    [SerializeField]
    private Canvas TutorialCanvas;
    [SerializeField]
    private Canvas NameCanvas;
    #endregion

    #region LogIn Elements
    [SerializeField]
    private InputField usernameL;
    [SerializeField]
    private InputField passwordL;
    [SerializeField]
    private Image black;
    #endregion

    #region SignIn Elements
    [SerializeField]
    private InputField usernameS;
    [SerializeField]
    private InputField passwordS;
    #endregion

    #region Sliders
    [SerializeField]
    private Slider sliderMusic;
    [SerializeField]
    private Slider sliderSound;
    #endregion

    [SerializeField]
    private Button exitGame;

    [SerializeField]
    private Button goBackFromNameCanvas;

    private bool comeFromConfig;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                exitGame.gameObject.SetActive(false);
            }

            comeFromConfig = false;

            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            NameCanvas.gameObject.SetActive(false);

            StartCoroutine(GameManager.GetInstance().Fade(black, false, 0.01f, ""));
        }
    }

    public void OnClickLogIn()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("LogIn Pulsado");
        //if (usernameL.text != "" && passwordL.text != "")
       
        if (usernameL.text != "" )
        {
            Debug.Log("user: " + usernameL.text + " pass: " + passwordL.text);
            StaticInfo.name = usernameL.text;
            if (PlayerPrefs.GetInt(StaticInfo.storyKey, 0) == 0)
            {
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.storyScene));
            }
            else
            {
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.navigationScene));
            }
        }
    }

    private void AddDefaultScores()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        ScoreData sd = JsonUtility.FromJson<ScoreData>(json);

        sd.scores.Add(new Score("Barracudo", 15000));
        sd.scores.Add(new Score("Hislleza", 14310));        
        sd.scores.Add(new Score("ManzAna", 13210));
        sd.scores.Add(new Score("Pisco", 13180));
        sd.scores.Add(new Score("Onion", 8830));
        sd.scores.Add(new Score("xXFishrXx", 6070));
        sd.scores.Add(new Score("Coralina", 3470));
        sd.scores.Add(new Score("Antonio", 2990));
        sd.scores.Add(new Score("Sobre Ruedas", 1230));
        sd.scores.Add(new Score("Pepe", 420));

        Debug.Log("Add Default");

        var json2 = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json2);
    }

    public void OnClickStart()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        if (PlayerPrefs.HasKey(StaticInfo.name))
        {
            if (PlayerPrefs.GetInt(StaticInfo.storyKey, 0) == 0)
            {
                AddDefaultScores();
                PlayerPrefs.SetInt(StaticInfo.storyKey, 1);
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.storyScene));
            }
            else
            {
                StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.navigationScene));
            }
        }
        else
        {
            AddDefaultScores();
            NameCanvas.gameObject.SetActive(true);
            LogInCanvas.gameObject.SetActive(false);
            goBackFromNameCanvas.gameObject.SetActive(false);
        }

    }

    public void OnClickSignIn()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("SignIn Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(true);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }
    public void OnClickContact()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Contact Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(true);
        TutorialCanvas.gameObject.SetActive(false);
    }
    public void OnClickConfiguration()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Opciones Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(true);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);
    }

    public void OnClickNameSet()
    {
        AudioManager.instance.PlaySound("ButtonSelected");
        //if (usernameL.text != "")
        //{
            PlayerPrefs.SetString(StaticInfo.name, usernameL.text);
            if (comeFromConfig)
            {
                AudioManager.instance.PlaySound("ButtonSelected");

                Debug.Log("Opciones Pulsado");
                NameCanvas.gameObject.SetActive(false);
                LogInCanvas.gameObject.SetActive(false);
                SignInCanvas.gameObject.SetActive(false);
                ConfigCanvas.gameObject.SetActive(true);
                SoundConfigCanvas.gameObject.SetActive(false);
                ContactCanvas.gameObject.SetActive(false);
                TutorialCanvas.gameObject.SetActive(false);
            }
            else
            {
                this.OnClickStart();
            }
        //}
        //else
        //{
        //    usernameL.placeholder.color = new Color(255,0,0,1);
        //    usernameL.placeholder.GetComponent<Text>().text = "Introduce un nuevo nombre";
        //}
    }

    public void OnClickTutorial()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Tutorial Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(true);
    }

    public void OnClickGoChangeName()
    {
        comeFromConfig = true;
        NameCanvas.gameObject.SetActive(true);

        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(false);
        ContactCanvas.gameObject.SetActive(false);
        TutorialCanvas.gameObject.SetActive(false);

        usernameL.text = "";
        goBackFromNameCanvas.gameObject.SetActive(true);
        if (PlayerPrefs.HasKey(StaticInfo.name))
        {
            usernameL.placeholder.GetComponent<Text>().text = "Nombre actual: " + PlayerPrefs.GetString(StaticInfo.name);
        }
        usernameL.placeholder.GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f, 1);

    }

    public void OnClickGoBack()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        if (ConfigCanvas.gameObject.activeSelf == true || SignInCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (SoundConfigCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(false);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(true);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (ContactCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (TutorialCanvas.gameObject.activeSelf == true)
        {
            LogInCanvas.gameObject.SetActive(true);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(false);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
        else if (NameCanvas.gameObject.activeSelf == true)
        {
            NameCanvas.gameObject.SetActive(false);
            LogInCanvas.gameObject.SetActive(false);
            SignInCanvas.gameObject.SetActive(false);
            ConfigCanvas.gameObject.SetActive(true);
            SoundConfigCanvas.gameObject.SetActive(false);
            ContactCanvas.gameObject.SetActive(false);
            TutorialCanvas.gameObject.SetActive(false);
        }
    }
    public void OnClickSoundConfig()
    {
        AudioManager.instance.PlaySound("ButtonSelected");

        Debug.Log("Opciones Sonido Pulsado");
        LogInCanvas.gameObject.SetActive(false);
        SignInCanvas.gameObject.SetActive(false);
        ConfigCanvas.gameObject.SetActive(false);
        SoundConfigCanvas.gameObject.SetActive(true);
        ContactCanvas.gameObject.SetActive(false);

        sliderMusic.value = PlayerPrefs.GetFloat(StaticInfo.volMusicKey);
        sliderSound.value = PlayerPrefs.GetFloat(StaticInfo.volSoundsKey);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void StartTutorial(int n)
    {
        StaticInfo.tutorialID = n;
        switch (n)
        {
            case 1:
                PlayerPrefs.SetInt(StaticInfo.tutorialNavKey, 1);
                break;
            case 2:
                PlayerPrefs.SetInt(StaticInfo.tutorialFishKey, 1);
                break;
            case 3:
                PlayerPrefs.SetInt(StaticInfo.tutorialShopKey, 1);
                break;
            case 4:
                PlayerPrefs.SetInt(StaticInfo.tutorialLevKey, 1);
                break;
        }
        StartCoroutine(GameManager.GetInstance().Fade(black, true, 0.01f, StaticInfo.tutorialScene));
    }
}
