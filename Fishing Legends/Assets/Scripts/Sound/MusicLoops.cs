using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoops : MonoBehaviour
{
    AudioSource source;

    public AudioClip menuClip;
    public AudioClip fishingClip;
    public AudioClip ruteIntroClip;
    public AudioClip ruteLoopClip;
    public AudioClip leviatanIntroClip;
    public AudioClip leviatanLoopClip;

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();

        switch (SceneManager.GetActiveScene().name)
        {
            case "StartScene":
                PlayClip(menuClip);
                break;
            case "FishingScene":
                PlayClip(fishingClip);
                break;
            case "NavigationScene":
                StartLoop(ruteIntroClip, ruteLoopClip);
                break;
            default:
                break;
        }
    }

    private void PlayClip(AudioClip clip)
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
    //private IEnumerator StartLoop(AudioClip introClip, AudioClip loopClip) {
    //    source.clip = introClip;
    //    source.loop = false;
    //    source.Play();
    //    yield return new WaitForSeconds(introClip.length);
    //    source.clip = loopClip;
    //    source.loop = true;
    //    source.Play();
    //}
    private void StartLoop(AudioClip introClip, AudioClip loopClip)
    {
        source.clip = loopClip;
        source.loop = true;
        source.PlayDelayed(introClip.length);
        source.clip = introClip;
        source.loop = false;
        source.Play();       
    }

}
