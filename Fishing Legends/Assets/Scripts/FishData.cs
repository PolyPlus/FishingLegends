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

    public string Name { get => name; set => name = value; }
    private int Size { get => size; set => size = value; }
    public int Points { get => points; set => points = value; }
    public int Rarity { get => rarity; set => rarity = value; }
    
    private void Start()
    {
        this.Name = this.gameObject.name;
    }
}
