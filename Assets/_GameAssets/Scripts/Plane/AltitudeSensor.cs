using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeSensor : MonoBehaviour
{
    public float altitude;
    public delegate void AltitudeAction(float f);
    public static event AltitudeAction OnChangeAltitude = delegate {};
    

    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo);
        altitude = hitInfo.distance;
        OnChangeAltitude(altitude);
    }
}



    