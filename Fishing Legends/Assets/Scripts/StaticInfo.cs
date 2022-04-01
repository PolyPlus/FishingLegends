using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInfo 
{
    // Start is called before the first frame update
    public static FishData[] staticFishDataList;

    public static int[] map;

    public static bool finishRoute = true;

    public static LinkedList<Vector3> indexPoints;
}
