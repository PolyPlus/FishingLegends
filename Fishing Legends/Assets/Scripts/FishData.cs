using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private int id;

    public string Name { get => name; set => name = value; }
    public int Size { get => size; set => size = value; }
    public int Points { get => points; set => points = value; }
    public int Rarity { get => rarity; set => rarity = value; }
    public int ID { get => id; set => id = value; }

    private void Start()
    {
        this.Name = this.gameObject.name;
    }

}
