using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraMovementController : MonoBehaviour
{
    private float offset = 10;
    private float speed = 20.0f;
    private Vector3 mRightDirection = Vector3.forward;
    private Vector3 mLeftDirection = -Vector3.forward;
    private Vector3 mDownDirection = Vector3.right;
    private Vector3 mUpDirection = -Vector3.right;

    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Mouse.current.position.ReadValue().x >= Screen.width - offset)
        {
            transform.position += mRightDirection * Time.deltaTime * speed;
        }else if (Mouse.current.position.ReadValue().x <= offset)
        {
            transform.position += mLeftDirection * Time.deltaTime * speed;
        } else if (Mouse.current.position.ReadValue().y >= Screen.height - offset)
        {
            transform.position += mUpDirection * Time.deltaTime * speed;
        } else if (Mouse.current.position.ReadValue().y <= offset)
        {
            transform.position += mDownDirection * Time.deltaTime * speed;
        }
    }
}
