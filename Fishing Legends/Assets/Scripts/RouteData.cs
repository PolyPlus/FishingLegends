using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RouteData
{

    public readonly Vector3 _p1;

    public readonly Vector3 _p2;

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
