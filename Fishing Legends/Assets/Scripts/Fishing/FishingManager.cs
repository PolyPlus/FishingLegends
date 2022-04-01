using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class FishingManager : MonoBehaviour
{
    
    public BaitStateManager baitManager;
    public RythmManager rythmGame;

    private int score;
    private PointerControlls controls;
    private bool paused;

    public bool Paused { get => paused; set => paused = value; }
    public int Score { get => score; set => score = value; }

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
}
