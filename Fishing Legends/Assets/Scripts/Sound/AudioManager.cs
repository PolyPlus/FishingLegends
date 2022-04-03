using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    public Sound[] sounds;
    public Sound[] soundtracks;
    
    [SerializeField]
    public AudioSource musicAudioSource;
    public AudioSource musicAudioSourceIntro;

    [SerializeField]
    public AudioMixer mixer;

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in soundtracks)
        {
            if (s.name == "TravesiaIntro" || s.name == "LeviatanIntro")
            {
                s.source = musicAudioSourceIntro;
            }
            else
            {
                s.source = musicAudioSource;
            }
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.outputAudioMixerGroup = s.outputMixer;
            s.source.Stop();
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.outputAudioMixerGroup = s.outputMixer;
        }
    }

    public void Start()
    {
        this.PlayAtStartScene(SceneManager.GetActiveScene().name);
    }

    public void SetVolumeMusic(float vol)
    {
        mixer.SetFloat("MusicVolume", vol);
        GameManager.GetInstance().volumeMusic = vol;
    }

    public void SetVolumeSounds(float vol)
    {
        mixer.SetFloat("SoundsVolume", vol);
    }

    #region PlayClipsMethods
    public void PlayAtStartScene(string sceneName)
    {
        musicAudioSource.Stop();
        musicAudioSourceIntro.Stop();
        switch (sceneName)
        {
            case "StartScene":
                PlaySoundtrack("MenuLoop");
                break;
            case "FishingScene":
                PlaySoundtrack("MinijuegoPesca");
                break;
            case "NavigationScene":
                StartLoop("TravesiaIntro", "TravesiaLoop");
                break;
            case "ShopScene":
                PlaySoundtrack("MenuLoop");
                break;
            case "StoryScene":
                PlaySoundtrack("MenuLoop");
                break;
            case "TutorialScene":
                PlaySoundtrack("MenuLoop");
                break;
            default:
                Debug.Log("Unknown Scene");
                break;
        }
    }
    public void PlaySoundtrack(string name)
    {
        Sound s = Array.Find(soundtracks, sound => sound.name == name);
        s.source.clip = s.clip;
        s.source.loop = true;
        s.source.Play();
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlaySound(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.volume = volume;
        s.source.Play();
    }

    public void PlayDelayed(string name, float time)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayDelayed(time);
    }

    private void StartLoop(string intro, string loop)
    {
        Sound sIntro = Array.Find(soundtracks, sound => sound.name == intro);
        Sound sLoop = Array.Find(soundtracks, sound => sound.name == loop);

        sIntro.source.clip = sIntro.clip;
        sIntro.source.loop = false;
        sIntro.source.Play();
        sLoop.source.clip = sLoop.clip;
        sLoop.source.loop = true;
        sLoop.source.PlayDelayed(sIntro.clip.length);
    }
    #endregion

    public IEnumerator FadeMusic(bool toSilent)
    {
        float vol, volTarget;
        AudioMixer mixer = AudioManager.instance.mixer;
        mixer.GetFloat("MusicVolume", out vol);
        volTarget = (toSilent) ? -40 : GameManager.GetInstance().volumeMusic;
        float inc = (toSilent) ? ((volTarget - Mathf.Abs(vol)) / 100) : Mathf.Abs((volTarget - Mathf.Abs(vol)) / 100);
        Debug.Log("Inicio: VolTarget: " + volTarget + "     Inc: " + inc);
        if (toSilent)
        {
            while (vol >= volTarget)
            {
                mixer.SetFloat("MusicVolume", vol + inc);
                yield return new WaitForSeconds(0.01f);
                mixer.GetFloat("MusicVolume", out vol);
            }
        }
        else
        {
            while (vol <= volTarget)
            {
                mixer.SetFloat("MusicVolume", vol + inc);
                yield return new WaitForSeconds(0.01f);
                mixer.GetFloat("MusicVolume", out vol);
            }
        }
    }

}
