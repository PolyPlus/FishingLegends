using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public float volumeMusic;

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
        volumeMusic = PlayerPrefs.GetFloat(StaticInfo.volMusicKey, 0.0f);
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
        //float vol, volTarget;
        ////AudioMixer mixer = AudioManager.instance.mixer;
        ////mixer.GetFloat("MusicVolume", out vol);
        //volTarget = (toBlack) ? -40 : this.volumeMusic;
        //float inc = (toBlack)?((volTarget - Mathf.Abs(vol))/ 100):Mathf.Abs((volTarget - Mathf.Abs(vol)) / 100);
        if (toBlack)
        {
            black.gameObject.SetActive(true);
            while (black.color.a < 1)
            {
                var color = black.color;
                color.a += 0.01f;
                black.color = color;
                //if(vol >= volTarget)
                //    mixer.SetFloat("MusicVolume", vol + inc);
                yield return new WaitForSeconds(speed);
                //mixer.GetFloat("MusicVolume", out vol);
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
                //if (vol <= volTarget)
                //    mixer.SetFloat("MusicVolume", vol + inc);
                yield return new WaitForSeconds(speed);
                //mixer.GetFloat("MusicVolume", out vol);
            }
            black.gameObject.SetActive(false);
        }
    }

}
