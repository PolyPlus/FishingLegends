using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public GameObject flechaDerecha;
    public GameObject flechaIzda;
    public GameObject flechaAbajo;
    public GameObject flechaArriba;
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
            flechaAbajo.SetActive(true);
        if (flechaArriba != null)
            flechaArriba.SetActive(true);
        if (flechaDerecha != null)
            flechaDerecha.SetActive(true);
        if (flechaIzda != null)
            flechaIzda.SetActive(true);
    }

    private void OnDisable()
    {
        cc.Disable(); 
        if (flechaAbajo != null)
            flechaAbajo.SetActive(false);
        if (flechaArriba != null)
            flechaArriba.SetActive(false);
        if (flechaDerecha != null)
            flechaDerecha.SetActive(false);
        if (flechaIzda != null)
            flechaIzda.SetActive(false);
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
            if (Pointer.current.position.ReadValue().x >= Screen.width - offset)
            {
                    
                transform.position += mRightDirection * Time.deltaTime * speed;
            }else if (Pointer.current.position.ReadValue().x <= offset)
            {
                transform.position += mLeftDirection * Time.deltaTime * speed;
            } else if (Pointer.current.position.ReadValue().y >= Screen.height - offset)
            {
                transform.position += mUpDirection * Time.deltaTime * speed;
            } else if (Pointer.current.position.ReadValue().y <= offset)
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
