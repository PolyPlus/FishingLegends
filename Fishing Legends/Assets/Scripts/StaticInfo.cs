using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticInfo 
{
    public static List<FishData> staticFishDataList;

    public static FishData[] staticFishData = null;

    public static int position;

    public static int[,] map;

    public static bool finishRoute = true;

    public static bool addRanking = false;

    public static string name = "name";

    public static int tutorialID;

    //public static LinkedList<Vector3> indexPoints;

    public static List<RouteData> route;
    
    // Guardar en playerPrefs
    public static int monedas, nivelBarco = 1, maxAnzuelos = 3;
    public static string volMusicKey = "volMusic", 
        volSoundsKey = "volSounds";
    // Actualizar en cada ruta
    public static int fishingScore, totalScore, numAnzuelos;

    public static Dictionary<int, bool> piscipedia;

    public static float probabilityByDistance;

    // Claves de Player Prefs
    public static string storyKey = "HistoriaVista", 
        monedasKey = "monedas", 
        nivelBarcoKey = "nivelBarco",
        maxAnzuelosKey = "maxAnzuelos",
        tutorialNavKey = "TutorialNavigationVisto",
        tutorialFishKey = "TutorialPescaVisto",
        tutorialShopKey = "TutorialTiendaVisto",
        tutorialLevKey = "TutorialLeviatanVisto";

    // Peces
    public static string[] fishKeys = { 
        "anguila", "Barracuda", "Caballito", "Cangrejo", 
        "Cirujano", "dorada", "Estrella", "gamba", "lenguado", "MantaRaya", 
        "mariposaMarina", "Cometa", "PezEspada", "PezGlobo", "pezLuna",
        "PezPayaso", "PeligrosoKey", "PeligrosoArcoirisKey", "Pulpo", 
        "Tiburon", "tortuga", "Leviatan"};

    // Nombres escenas
    public static string navigationScene = "NavigationScene",
        tutorialScene = "TutorialScene",
        storyScene = "StoryScene",
        fishingScene = "FishingScene",
        shopScene = "ShopScene",
        startScene = "StartScene",
        leviatanSecene = "LeviathanScene";
}
