using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.eulerAngles.x != 0 || transform.eulerAngles.z != 0)
        {
            Vector3 newRotation = transform.eulerAngles;
            newRotation.x = newRotation.z = 0;
            transform.eulerAngles = newRotation;
        }
    }

    void MoveCar(Vector2 input)
    {
        Vector3 backWheelForce = new Vector3(0, 0, input.y);
        backWheelForce.Normalize();
        Vector3 frontWheelForce = new Vector3(input.x,0,0);
        frontWheelForce.Normalize();
        frontWheelForce = transform.TransformDirection(frontWheelForce);
        backWheelForce = transform.TransformDirection(backWheelForce);
        rb.AddForceAtPosition(backWheelForce * 9.0f, transform.position - transform.forward * 0.3f);
        rb.AddForceAtPosition((input.y>0?frontWheelForce:(-frontWheelForce)) * 8.0f, transform.position + transform.forward * 0.3f);
    }
}
