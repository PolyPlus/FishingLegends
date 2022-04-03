using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    #region Variables

    public GameObject gridPoint;

    private Animator transition;

    public GameObject transition_go;

    private Camera _camera;

    private Ray _ray;

    public int _rowsColumns;

    public GameObject boat;

    public GameObject topCamera;

    public ActualizarResultados resultados;
    
    public GameObject block, tree, fishbank, rock;

    private Vector3 gridOffset,pointOrigin;

    private Vector3 min,max;

    private RaycastHit _a;

    private FishData[] _fishDataList;

    private ClickController cc;

    private InputAction clickaction;

    private int currentPositionX, currentPositionY, lastPositionX, lastPositionY;
    
    private LinkedList<Vector3> indexPoints = new LinkedList<Vector3>();
    private LinkedList<GameObject> gridPointList = new LinkedList<GameObject>();

    private List<RouteData> route = new List<RouteData>();

    private float t;

    private bool routeStarted,stop;

    private int routeIndex;

    public uint maxFuel;

    private bool inHold,release;
    
    private bool preRoute;

    private int[,] blockType;

    private GameObject grid;

    #endregion
    

    private void Awake()
    {
        boat.GetComponentInChildren<Renderer>().material.renderQueue = 1998;
        cc = new ClickController();
    }

    private void OnEnable()
    {
        cc.Enable();
    }

    private void OnDisable()
    {
        cc.Disable();
    }

    
    void Start()
    {

        _camera = Camera.main;
        cc.pointer.press.started += _ => OnHold();
        cc.pointer.press.canceled += _ => OnRelease();
        t = 0;
        stop = false;
        routeIndex = 0;
        inHold = false;
        preRoute = true;

        grid = GameObject.Find("Grid");

        grid.GetComponent<Renderer>().material.SetFloat("_CellSize", (10.0f) / _rowsColumns);

        transition = transition_go.GetComponent<Animator>();
        

        Collider auxCol = GetComponent<Collider>();

        max = auxCol.bounds.max;
        min = auxCol.bounds.min;
        gridOffset = (max - min) / (float) _rowsColumns;
        pointOrigin = min + gridOffset / 2.0f;

        blockType = new int[_rowsColumns, _rowsColumns];
        
        // 0 peces
        // 1 tierra
        // 2 tierra-arbol
        // 3 roca
        

        blockType[8, 8] = 3;
        blockType[8, 9] = 2;
        blockType[8, 10] = 3;
        blockType[9, 8] = 2;
        blockType[9, 9] = 2;
        blockType[9, 10] = 3;
        
        blockType[2, 1] = 2;
        blockType[3, 1] = 3;
        blockType[4, 1] = 2;
        blockType[16, 1] = 3;
        blockType[17, 1] = 2;
        
        blockType[2, 2] = 2;
        blockType[3, 2] = 2;
        blockType[4, 2] = 2;
        blockType[10, 2] = 2;
        blockType[11, 2] = 3;
        blockType[15, 2] = 2;
        blockType[16, 2] = 2;
        blockType[17, 2] = 2;
        
        blockType[1, 3] = 2;
        blockType[2, 3] = 3;
        blockType[3, 3] = 2;
        blockType[11, 3] = 2;
        blockType[12, 3] = 2;
        blockType[15, 3] = 3;
        blockType[16, 3] = 2;
        blockType[17, 3] = 3;

        blockType[1, 4] = 3;
        blockType[2, 4] = 2;
        blockType[3, 4] = 2;
        blockType[15, 4] = 2;
        blockType[16, 4] = 2;
        
        blockType[1, 5] = 2;
        blockType[2, 5] = 2;
        blockType[3, 5] = 3;
        blockType[15, 5] = 2;
        blockType[16, 5] = 3;
        
        blockType[1, 6] = 3;
        blockType[2, 6] = 2;
        blockType[15, 6] = 2;
        
        blockType[1, 7] = 2;
        blockType[2, 7] = 2;

        
        blockType[1, 13] = 2;
        blockType[1, 14] = 2;
        blockType[1, 15] = 2;
        blockType[2, 12] = 2;
        blockType[2, 13] = 2;
        blockType[2, 14] = 3;
        blockType[2, 15] = 2;
        blockType[2, 16] = 3;
        blockType[3, 14] = 2;
        blockType[3, 15] = 2;
        blockType[3, 16] = 2;
        blockType[3, 17] = 2;
        blockType[4, 15] = 3;
        blockType[4, 16] = 2;
        blockType[4, 17] = 2;
        blockType[5, 16] = 2;
        blockType[5, 17] = 2;
        blockType[6, 16] = 2;
        blockType[6, 17] = 3;
        blockType[7, 17] = 2;
        
        blockType[12, 14] = 3;
        blockType[12, 15] = 2;
        blockType[12, 16] = 2;
        blockType[13, 15] = 2;
        blockType[13, 16] = 3;
        blockType[13, 17] = 2;
        blockType[13, 18] = 2;
        blockType[14, 17] = 2;
        blockType[14, 18] = 2;
        blockType[15, 13] = 2;
        blockType[15, 17] = 3;
        blockType[15, 18] = 2;
        blockType[16, 13] = 3;
        blockType[16, 14] = 2;
        blockType[16, 15] = 2;
        blockType[16, 16] = 2;
        blockType[16, 17] = 2;
        blockType[16, 18] = 2;
        blockType[17, 14] = 2;
        blockType[17, 15] = 3;
        blockType[17, 16] = 2;
        blockType[17, 17] = 2;
        

        
        blockType[10, 9] = -1;
        blockType[10, 10] = -1;
        blockType[10, 8] = 5;
        blockType[11, 8] = -1;
        blockType[11, 9] = -1;
        blockType[11, 10] = -1;

        if (StaticInfo.finishRoute)
        {
            lastPositionX = 10;
            lastPositionY = 9;
        
            GenerateMapContent();

            Vector3 start = TransformIdToGrid(lastPositionX, lastPositionY, new Vector3(0, 1.7f, 0));

            indexPoints.AddLast(start);
        

            gridPoint.transform.position = start;         

            Instantiate(gridPoint, start, Quaternion.identity);

           
        }
        else
        {
           // indexPoints = StaticInfo.indexPoints;
            blockType = StaticInfo.map;
            route = StaticInfo.route;
            routeIndex = StaticInfo.position;
            for (int i = 0; i < route.Count; i++)
            {
                Instantiate(gridPoint, route.ElementAt(i)._p1, Quaternion.identity);
            }
            Instantiate(gridPoint, route.ElementAt(route.Count - 1)._p1, Quaternion.identity);
            
            routeStarted = true;
            topCamera.transform.rotation = Quaternion.Euler(30,0,0);
        }
        
        InitializeMap();
      
        //GetComponent<Collider>().bounds.
    }

    // Update is called once per frame
    void Update()
    {
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

       

        if (routeStarted)
        {

            if (!stop)
            {
                if (t > 1.0f)
                {
                    t -= 1.0f;
                    routeIndex++;
                   
                
                }
                t += Time.deltaTime*0.6f;
                
                if (routeIndex < route.Count)
                {
                    boat.transform.LookAt(route.ElementAt(routeIndex)._p2);
                    //Debug.Log(routeIndex);
                    boat.transform.position = route[routeIndex].GetPoint(t);
                    topCamera.transform.position = boat.transform.position + new Vector3(6, 20, -27);

                    if (blockType[TransformCoordinateToId(boat.transform.position.x, max.x, min.x),
                            TransformCoordinateToId(boat.transform.position.z, max.z, min.z)] == 1)
                    {
                        blockType[TransformCoordinateToId(boat.transform.position.x, max.x, min.x),
                            TransformCoordinateToId(boat.transform.position.z, max.z, min.z)] = 0;
                        stop = true;
                        StaticInfo.route = route;
                        StaticInfo.map = blockType;
                        StaticInfo.position = routeIndex;
                        StaticInfo.finishRoute = false;
                        transition.SetBool("fadingIn",true);
                    }
                }
                else
                {
                    stop = true;
                    StaticInfo.finishRoute = true;
                    resultados.sr.gameObject.SetActive(true);
                    resultados.mostrarPeces(StaticInfo.staticFishData);
                }
            }
            
            
            
            
            
            

        } else  if (Physics.Raycast(_ray, out _a))
        {
            
            if (preRoute)
            {
                if (release)
                {
                    if ( _a.collider.gameObject.name == "casita" )
                    {
                        Debug.Log("CASSA");
                        GameManager.GetInstance().SelectScene(StaticInfo.shopScene);
                        release = false;
                    }
                    else if (_a.collider.gameObject.name == "Bote")
                    {
                        preRoute = false;
                        transition.SetBool("toRoute",true);
                        topCamera.GetComponent<CameraMovementController>().enabled = true;
                        Debug.Log("BARCO");
                        release = false;

                        StaticInfo.numAnzuelos = StaticInfo.maxAnzuelos;
                    }
                    else
                    {
                        release = false;
                    }
                }
            }
            else
            {
                currentPositionX = ((int) (_rowsColumns * (_a.point.x - min.x) / (max.x - min.x)));
                currentPositionY = ((int) (_rowsColumns * (_a.point.z - min.z) / (max.z - min.z)));
                //_a.collider.gameObject
                Vector3 newPoint = TransformIdToGrid(currentPositionX, currentPositionY, _a.point);

                if (((((currentPositionX == lastPositionX + 1 || currentPositionX == lastPositionX - 1 ||
                        currentPositionX == lastPositionX) &&
                       (currentPositionY == lastPositionY + 1 || currentPositionY == lastPositionY - 1 ||
                        currentPositionY == lastPositionY)) &&
                      !(currentPositionX == lastPositionX && currentPositionY == lastPositionY)) || indexPoints.Count == 0) && blockType[currentPositionX,currentPositionY] <= 1 )
                {
                    gridPoint.transform.position = newPoint;
                    //  Debug.Log(gridPoint.transform.position);
                    if (inHold && indexPoints.Count < maxFuel )
                    {

                        GameObject cloned = Instantiate(gridPoint, newPoint, Quaternion.identity);
                        //selectedPositions[currentPositionX, currentPositionY] = true;
                        lastPositionX = currentPositionX;
                        lastPositionY = currentPositionY;
                        indexPoints.AddLast(newPoint);
                        gridPointList.AddLast(cloned);
                        // Debug.Log(indexPoints.Count);
                        //curvePoints.AddLast(new Vector2(cloned.transform.position.x,,))

                    }
                }
            }
            
            
        }else if (release)
        {
            release = false;
        }
    }

   

    void ProcessRoute()
    {
        for (int i = 0; i < indexPoints.Count - 1; i++)
        {

            route.Add(new RouteData(indexPoints.ElementAt(i), indexPoints.ElementAt(i + 1)));
        }
    }
    


    Vector3 TransformIdToGrid(int currentPosx,int currentPosY, Vector3 pos)
    {
        
        //Debug.Log(pos);
        return new Vector3(currentPosx*gridOffset.x + pointOrigin.x,pos.y ,currentPosY*gridOffset.z + pointOrigin.z);
        
    }

    int TransformCoordinateToId(float coordinate,float max, float min)
    {
        return ((int) (_rowsColumns * (coordinate - min) / (max - min)));
    }

    private void OnHold()
    {
        inHold = true;
        //release = false;
    }
    
    private void OnRelease()
    {
        inHold = false;
        release = true;
    }

    public void startRoute()
    {
        
         if(TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count-1).x,min.x,max.x) 
         ==  TransformCoordinateToId(indexPoints.ElementAt(0).x,min.x,max.x) && TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count-1).z,min.z,max.z) 
         ==  TransformCoordinateToId(indexPoints.ElementAt(0).z,min.z,max.z) && indexPoints.Count > 1) 
         {
             
             topCamera.GetComponent<CameraMovementController>().enabled = false;
             //transition.SetBool("fadingIn",true);
             topCamera.transform.rotation = Quaternion.Euler(30,0,0);
             ProcessRoute();
       
        routeStarted = true;
            grid.SetActive(false);
            //topCamera.SetActive(false);
            
         }
        
    }

    public void undoRoutePoint()
    {
        if (indexPoints.Count > 1)
        {
            indexPoints.RemoveLast();
            lastPositionX = TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count - 1).x, max.x, min.x);
            lastPositionY = TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count - 1).z, max.z, min.z);
        }
        if (gridPointList.Count > 0)
        {
            Destroy(gridPointList.ElementAt(gridPointList.Count - 1));
            gridPointList.RemoveLast();
        }
       
        
    }

    public void atras()
    {
        transition.SetBool("reloadScene", true);
    }

    private void GenerateMapContent()
    {
        bool isFish = true;
        for (int i = 0; i < _rowsColumns; i++)
        {
            for (int j = 0; j < _rowsColumns; j++)
            {
                
                
                j += Random.Range(1, 12);

                if (j < _rowsColumns)
                {
                    if (blockType[i,j] ==  0)
                    {
                        if (isFish)
                        {
                            blockType[i,j] = 1;
                        }
                        else
                        {
                            blockType[i,j] = 4;
                        }
                        
                    }
                    
                }
                
                isFish = !isFish;
                
            }

            

        }
    }
    private void InitializeMap()
    {
        for (int i = 0; i < blockType.GetLength(0); i++)
        {
            for (int j = 0; j < blockType.GetLength(1); j++)
            {
                 switch (blockType[i, j]) {
                   case 1:
                       Instantiate(fishbank,TransformIdToGrid(i,j,new Vector3(0,0,0)), Quaternion.identity);
                         break;
                   case 2:
                        Instantiate(block,TransformIdToGrid(i,j,new Vector3(0,1,0)),block.transform.rotation);
                         break;
                   case 3:
                       Instantiate(block,TransformIdToGrid(i,j,new Vector3(0,1,0)),block.transform.rotation);
                       Instantiate(tree,TransformIdToGrid(i,j,new Vector3(0,10,0)),tree.transform.rotation);
                       break;
                   case 4:
                       Instantiate(rock,TransformIdToGrid(i,j,new Vector3(0,1,0)),rock.transform.rotation);
                       break;
                     
                 }
            }
        }
    }
}
