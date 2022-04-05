using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class FishingManager : MonoBehaviour
{
    
    public BaitStateManager baitManager;
    public RythmManager rythmGame;
    public LureUI lureUI;
    public bool exit;
    
    private int numAnzuelos = 3;
    private int score;
    private PointerControlls controls;
    private FishData[] fishCaught;
    private bool paused;

    public bool Paused { get => paused; set => paused = value; }
    public int Score { get => score; set => score = value; }
    public FishData[] FishCaught { get => fishCaught; set => fishCaught = value; }

    private void Awake()
    {
        Paused = false;
        controls = new PointerControlls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        exit = false;
        numAnzuelos = StaticInfo.numAnzuelos;
        lureUI.SetNumAnzuelos(numAnzuelos);
        controls.Pointer.Press.started += _ => OnPointerPress();
        controls.Pointer.Press.canceled += _ => OnPointerRelease();
        baitManager.RythmGame = rythmGame;
        baitManager.FishingManager = this;
        rythmGame.BaitManager = baitManager;
        Score = 0;
    }

    private void OnPointerPress()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        if (rythmGame.started)
        {
            Paused = true;
            rythmGame.OnPointerPress(mousePosition);
        }
        else
        {
            Paused = false;
        }
        //Debug.Log("Pointer Press on" + mousePosition);
    }

    private void OnPointerRelease()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        //Debug.Log("Pointer Release on" + mousePosition);
    }

    public void OnClick()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        if (!Paused) baitManager.OnPointerPress(mousePosition);
    }

    public void UseLure()
    {
        if(numAnzuelos>0) numAnzuelos --;
        lureUI.SetNumAnzuelos(numAnzuelos);
        StaticInfo.numAnzuelos = numAnzuelos;
        if(numAnzuelos <= 0)
        {
            exit = true;
            //GameManager.GetInstance().SelectScene(StaticInfo.navigationScene);
        }
    }

    public void UpdateFishData(FishData[] data)
    {
        /*  */
        FishCaught = data;
        //if (StaticInfo.staticFishData == null)
        //    StaticInfo.staticFishData = data;
        //else
        //{
        //    FishData[] d = StaticInfo.staticFishData.Concat(data).ToArray();
        //    StaticInfo.staticFishData = d;
        //}

        //for (int i = 0; i < StaticInfo.staticFishData.Length; i++)
        //{
        //    Debug.Log(StaticInfo.staticFishData[i]);
        //}
    }

    public void UpdateScore(int s)
    {
        StaticInfo.fishingScore += s;
    }
}
