using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI textAltitude;
    public TextMeshProUGUI textSpeed;
    void OnEnable()
    {
        AltitudeSensor.OnChangeAltitude += RefreshAltitude;
        SimplePlaneController.OnChangeSpeed += RefreshSpeed;
    }


    void OnDisable()
    {
        AltitudeSensor.OnChangeAltitude -= RefreshAltitude;
    }


    void RefreshAltitude(float altitude)
    {
        textAltitude.text = ((int)altitude)+" ft";
    }
    void RefreshSpeed(float speed)
    {
        textSpeed.text = ((int)speed)+" kn";
    }
}
