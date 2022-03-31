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

    //public GameObject boatCamera;

    // private bool[,] selectedPositions;

    public GameObject block;

    public GameObject tree;
    
    public GameObject fishbank;

    //public GameObject fishBank;

    private Vector3 gridOffset;

    private Vector3 pointOrigin;

    private Vector3 min;

    private Vector3 max;

    public Image a;

    private RaycastHit _a;

    private ClickController cc;

    private InputAction clickaction;

    private int currentPositionX, currentPositionY;

    private int lastPositionX, lastPositionY;

    private LinkedList<Vector3> indexPoints = new LinkedList<Vector3>();

    private List<RouteData> route = new List<RouteData>();

    private float t;

    private bool routeStarted;

    private bool stop;

    private int routeIndex;

    public uint maxFuel;

    private bool inHold;

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
        
        blockType[2, 2] = 2;
        blockType[2, 3] = 2;
        blockType[3, 2] = 3;
        blockType[3, 3] = 2;

        blockType[12, 12] = 2;
        blockType[12, 13] = 2;
        blockType[13, 12] = 2;
        blockType[13, 13] = 3;
        
       // blockType[15, 13] = 1;
        blockType[18, 13] = 1;


        blockType[22, 22] = 3;
        blockType[22, 23] = 2;
        blockType[23, 22] = 2;
        blockType[23, 23] = 2;

        lastPositionX = 14;
        lastPositionY = 13;
        
        GenerateMapContent();

        Vector3 start = TransformIdToGrid(lastPositionX, lastPositionY, new Vector3(0, 0, 0));

        indexPoints.AddLast(start);

        gridPoint.transform.position = start;

        Instantiate(gridPoint, start, Quaternion.identity);

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
                t += Time.deltaTime;
                
                if (routeIndex < route.Count)
                {
                    boat.transform.LookAt(indexPoints.ElementAt(routeIndex + 1));
                    //Debug.Log(routeIndex);
                    boat.transform.position = route[routeIndex].GetPoint(t);
                    topCamera.transform.position = boat.transform.position + new Vector3(-1, 7, -12);

                    if (blockType[TransformCoordinateToId(boat.transform.position.x, max.x, min.x),
                            TransformCoordinateToId(boat.transform.position.z, max.z, min.z)] == 1)
                    {
                        stop = true;
                        transition.SetBool("fadingIn",true);
                    }
                }
                else
                {
                    stop = true;
                    //EN ESTE ELSE SE EJECUTA CUANDO ACABA LA RUTA
                }
            }
            
            
            
            
            
            

        } else  if (Physics.Raycast(_ray, out _a))
        {
            //_a.point.Lo;
            currentPositionX = ((int) (_rowsColumns * (_a.point.x - min.x) / (max.x - min.x)));
            currentPositionY = ((int) (_rowsColumns * (_a.point.z - min.z) / (max.z - min.z)));
            
            
            
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
                   // Debug.Log(indexPoints.Count);
                    //curvePoints.AddLast(new Vector2(cloned.transform.position.x,,))

                }
            }
        }
    }

    struct RouteData
    {
        //private bool isBezier;

        private readonly Vector3 _p1;

        private readonly Vector3 _p2;

       

        public RouteData(Vector3 p1, Vector3 p2)
        {
            _p1 = p1;
            _p2 = p2;
            
        }
        public Vector3 GetPoint(float t)
        {
            return _p1 + t * (_p2 - _p1);
            
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
        
        
        
    }
    
    private void OnRelease()
    {
        inHold = false;
        
    }

    public void startRoute()
    {
        
         if(TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count-1).x,min.x,max.x) 
         ==  TransformCoordinateToId(indexPoints.ElementAt(0).x,min.x,max.x) && TransformCoordinateToId(indexPoints.ElementAt(indexPoints.Count-1).z,min.z,max.z) 
         ==  TransformCoordinateToId(indexPoints.ElementAt(0).z,min.z,max.z) && indexPoints.Count > 1) 
         {
             
             topCamera.GetComponent<CameraMovementController>().enabled = false;
             //transition.SetBool("fadingIn",true);
             topCamera.transform.rotation = Quaternion.identity;
             ProcessRoute();
       
        routeStarted = true;
            grid.SetActive(false);
            //topCamera.SetActive(false);
            
         }
        
    }


    private void GenerateMapContent()
    {
        for (int i = 0; i < _rowsColumns; i++)
        {
            for (int j = 0; j < _rowsColumns; j++)
            {
                
                
                j += Random.Range(1, 12);

                if (j < _rowsColumns)
                {
                    if (blockType[i,j] ==  0)
                    {
                        blockType[i,j] = 1;
                    }
                    
                }
                
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
                       //Instantiate(block,TransformIdToGrid(i,j,new Vector3(0,1,0)),block.transform.rotation);
                       break;
                     
                 }
            }
        }
    }
}
