using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraMovementController : MonoBehaviour
{
    private float offset = 100;
    private float speed = 30.0f;
    private Ray _ray;
    private RaycastHit _a;
    private Vector3 mRightDirection = Vector3.forward;
    private Vector3 mLeftDirection = -Vector3.forward;
    private Vector3 mDownDirection = Vector3.right;
    private Vector3 mUpDirection = -Vector3.right;
    private bool hold;
    private ClickController cc;

    public RouteArrow flechaDerecha;
    public RouteArrow flechaIzda;
    public RouteArrow flechaAbajo;
    public RouteArrow flechaArriba;
    public Collider gridcol;

    private Camera _camera;
    

    private void Awake()
    {
       
        cc = new ClickController();

    }

    private void OnEnable()
    {
        cc.Enable();
        if (flechaAbajo != null)
            flechaAbajo.gameObject.SetActive(true);
        if (flechaArriba != null)
            flechaArriba.gameObject.SetActive(true);
        if (flechaDerecha != null)
            flechaDerecha.gameObject.SetActive(true);
        if (flechaIzda != null)
            flechaIzda.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        cc.Disable(); 
        if (flechaAbajo != null)
            flechaAbajo.gameObject.SetActive(false);
        if (flechaArriba != null)
            flechaArriba.gameObject.SetActive(false);
        if (flechaDerecha != null)
            flechaDerecha.gameObject.SetActive(false);
        if (flechaIzda != null)
            flechaIzda.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    
    { 
        cc .pointer.press.started += _ => OnHold();
        cc.pointer.press.canceled += _ => OnRelease();
        _camera = Camera.main;
    }

    void OnHold()
    {
        hold = true;
    }

    void OnRelease()
    {
        hold = false;
    }
    
    // Update is called once per frame
    void Update()
    {
       

        if (hold)
        {
            
            _ray = _camera.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2));
       
            Vector3 lastpos  = transform.position;

           
           
            
            if ( flechaDerecha.pointerOver)
            {
                transform.position += mRightDirection * Time.deltaTime * speed;
            }else if (flechaIzda.pointerOver)
            {
                transform.position += mLeftDirection * Time.deltaTime * speed;
            } else if (flechaArriba.pointerOver )
            {
                transform.position += mUpDirection * Time.deltaTime * speed;
            } else if (flechaAbajo.pointerOver)
            {
                transform.position += mDownDirection * Time.deltaTime * speed;
            }
            if (Physics.Raycast(_ray, out _a) )
            {
            
                if (!(transform.position.x > gridcol.bounds.min.x + 55 && transform.position.x < gridcol.bounds.max.x - 30 &&
                      transform.position.z > gridcol.bounds.min.z + 60   && transform.position.z < gridcol.bounds.max.z - 60))
                {

                    transform.position = lastpos;

                }
            
            }

        }
       
        
    }
    
}
