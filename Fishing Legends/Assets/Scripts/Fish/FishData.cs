using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishData : MonoBehaviour
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int size;
    [SerializeField]
    private int points;
    [SerializeField]
    private int rarity;

    private void Start()
    {
        this.name = this.gameObject.name;
    }
}
