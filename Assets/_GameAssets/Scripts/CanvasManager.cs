using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI textAltitude;
    void OnEnable()
    {
        AltitudeSensor.OnChangeAltitude += RefreshAltitude;
    }


    void OnDisable()
    {
        AltitudeSensor.OnChangeAltitude -= RefreshAltitude;
    }


    void RefreshAltitude(float altitude)
    {
        textAltitude.text = ((int)altitude).ToString("");
    }
}
