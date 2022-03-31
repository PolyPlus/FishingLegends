using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadMain()
    {
        GameObject main = GameObject.Instantiate(Resources.Load("GameManager")) as GameObject;
        GameObject.DontDestroyOnLoad(main);
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void SelectScene(string nameScene)
    {
        AudioManager.instance.PlayAtStartScene(nameScene);
        SceneManager.LoadScene(nameScene);
    }
}
