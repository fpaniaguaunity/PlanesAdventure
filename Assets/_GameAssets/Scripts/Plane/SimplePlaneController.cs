using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlaneController : MonoBehaviour
{
    private const float MODIFY_SPEED_DELAY = 0.1f;

    public float speed;
    public float maxSpeed;
    public float deltaSpeed;
    public float angularSpeed;
    public float rotationSpeed;
    private float h, v, z;

    public delegate void SpeedAction(float f);
    public static event SpeedAction OnChangeSpeed = delegate {};

    private void Start() {
        OnChangeSpeed(speed);    
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * angularSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * v * angularSpeed * Time.deltaTime);
        transform.Rotate(Vector3.forward * z * rotationSpeed * Time.deltaTime);
    }

    private void Accelerate()
    {
        if (speed < maxSpeed)
        {
            speed += deltaSpeed;
            speed = Mathf.Min(speed, maxSpeed);
            OnChangeSpeed(speed);
        }
    }

    private void Decelerate()
    {
        if (speed > 0)
        {
            speed -= deltaSpeed;
            speed = Mathf.Max(speed, 0);
            OnChangeSpeed(speed);
        }
    }

    #region Input Messages Managers

    private void OnMove(InputValue inputValue)
    {
        h = inputValue.Get<Vector2>().x;
        v = inputValue.Get<Vector2>().y;
    }

    private void OnRotate(InputValue inputValue)
    {
        z = inputValue.Get<Vector2>().x;
    }

    private void OnAccelerate(InputValue value)
    {
        if (value.isPressed)
        {
            InvokeRepeating("Accelerate", 0, MODIFY_SPEED_DELAY);
        }
        else
        {
            CancelInvoke("Accelerate");
        }
    }

    private void OnDecelerate(InputValue value)
    {
        if (value.isPressed)
        {
            InvokeRepeating("Decelerate", 0, MODIFY_SPEED_DELAY);
        }
        else
        {
            CancelInvoke("Decelerate");
        }
    }

    #endregion
}
