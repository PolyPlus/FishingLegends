using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishData : MonoBehaviour
{
    [SerializeField]
    private string fishName;
    [SerializeField]
    private int size;
    [SerializeField]
    private int points;
    [SerializeField]
    private int commonality;
    [SerializeField]
    private int id;

    public string Name { get => fishName; set => fishName = value; }
    public int Size { get => size; set => size = value; }
    public int Points { get => points; set => points = value; }
    public int Commonality { get => commonality; set => commonality = value; }
    public int ID { get => id; set => id = value; }

    private void Start()
    {
        this.Name = this.gameObject.name;
    }

}
