using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo 
{
    public static List<FishData> staticFishDataList;

    public static FishData[] staticFishData;

    public static int[] map;

    public static bool finishRoute = true;

    public static LinkedList<Vector3> indexPoints;
    // Guardar en playerPrefs
    public static int monedas, nivelBarco = 1, maxAnzuelos = 5;
    // Actualizar en cada ruta
    public static int fishingScore, totalScore, numAnzuelos;

    public static Dictionary<int, bool> piscipedia;    
}
