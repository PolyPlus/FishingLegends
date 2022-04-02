using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class FishingManager : MonoBehaviour
{
    public BaitStateManager baitManager;
    public RythmManager rythmGame;
    public int score;
    private PointerControlls controls;

    private void Awake()
    {
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
        baitManager.rythmGame = rythmGame;
        rythmGame.baitManager = baitManager;
        score = 0;
    }

    private void OnPointerPress()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        baitManager.OnPointerPress(mousePosition);
        if(rythmGame.started)rythmGame.OnPointerPress(mousePosition);
        //Debug.Log("Pointer Press on" + mousePosition);
    }

    private void OnPointerRelease()
    {
        Vector2 mousePosition = controls.Pointer.Position.ReadValue<Vector2>();
        //Debug.Log("Pointer Release on" + mousePosition);
    }

}
