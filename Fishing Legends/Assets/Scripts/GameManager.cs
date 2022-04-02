using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public IEnumerator Fade(Image black, bool toBlack, float speed, string scene)
    {
        if (toBlack)
        {
            black.gameObject.SetActive(true);
            while (black.color.a < 1)
            {
                var color = black.color;
                color.a += 0.01f;
                black.color = color;
                yield return new WaitForSeconds(speed);
            }
            GameManager.GetInstance().SelectScene(scene);
        }
        else
        {
            while (black.color.a > 0)
            {
                var color = black.color;
                color.a -= 0.01f;
                black.color = color;
                yield return new WaitForSeconds(speed);
            }
            black.gameObject.SetActive(false);
        }
    }

}
