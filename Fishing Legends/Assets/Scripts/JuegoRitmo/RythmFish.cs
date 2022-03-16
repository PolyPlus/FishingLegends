using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmFish : MonoBehaviour
{      
    public bool derecha;
    public float speed;

    public GameObject latIz;
    public GameObject latDer;
    private RythmManager rythmManager;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position==latIz.transform.position)
        {
            derecha = false;
        }
        else
        {
            derecha = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (derecha)
        {
            transform.Translate(new Vector2(-1, 0f) * Time.deltaTime * speed);
            if (transform.position.x < latIz.transform.position.x)  //Si se te escapa el pez y pasa ese margen
            {
                Destroy(gameObject); //Lo elimina
            }
        }
        else
        {
            transform.Translate(new Vector2(-1, 0f) * Time.deltaTime * speed);
            if (transform.position.x > latDer.transform.position.x)  //Si se te escapa el pez y pasa ese margen
            {
                Destroy(gameObject); //Lo elimina
            }
        }
    }

    public void Init(RythmManager _rythmManager, GameObject _latIzq, GameObject _latDer, float _speed)
    {
        rythmManager = _rythmManager;
        latIz = _latIzq;
        latDer = _latDer;
        speed = _speed;
    }

}
