using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScriptPscipedia : MonoBehaviour
{
    public Sprite octopus;
    public Sprite seaHorse;
    public Sprite dangerousFish;
    public Sprite clownfish;
    public Sprite star;
    public Sprite sharp;
    public Sprite swordfish;
    public Sprite kiteFish;
    public Sprite barracuda;
    public Sprite surgeonFish;
    public Sprite crab;
    public Sprite stingray;
    public Sprite blowFish;

   // public bool change = false;
   // public int fishID=3;
    private Sprite[] fishes;
    // Start is called before the first frame update
    void Start()
    {
        fishes = new Sprite[] { barracuda,seaHorse, crab,surgeonFish,star,stingray,kiteFish,swordfish,blowFish, clownfish,dangerousFish,octopus, sharp };
        for(int i=0; i<fishes.Length; i++)
        {
            if (PlayerPrefs.GetInt(StaticInfo.fishKeys[i], 0) > 0)
            {
                changeImage(i);
            }
        }
    }

    void changeImage(int fishID)
    {
        if ((fishID >=0) && (fishID < fishes.Length))
        {
            transform.GetChild(fishID).GetComponent<Image>().sprite = fishes[fishID];
        }
    }
}
