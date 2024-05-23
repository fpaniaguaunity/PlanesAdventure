using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlaneController : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    public float rotationSpeed;
    private float h, v, z;


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * angularSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * v * angularSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * z * rotationSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue inputValue)
    {
        h = inputValue.Get<Vector2>().x;
        v = inputValue.Get<Vector2>().y;
    }

    private void OnRotate(InputValue inputValue)
    {
        z = inputValue.Get<Vector2>().x;
    }
}