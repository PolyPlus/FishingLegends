using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishData : MonoBehaviour
{

    private enum fishSize
    {
        Small,
        Medium,
        Large,
        Enemy
    }

    [SerializeField]
    private string name;
    [SerializeField]
    private fishSize size;
    [SerializeField]
    private int points;
    [SerializeField]
    private int rarity;

    private void Start()
    {
        this.name = this.gameObject.name;
    }
}
