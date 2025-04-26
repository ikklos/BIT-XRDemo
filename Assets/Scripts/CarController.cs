using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class CarController : MonoBehaviour
{
    public GameObject car;
    public InputActionReference actionReference;
    private float offsetTimer = 0.01f;
    private bool grabbing = false;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(SetGrabbing);
        interactable.selectExited.AddListener(RemoveGrabbing);
    }

    void OnDestroy()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (grabbing)
        {
            offsetTimer -= Time.deltaTime;
            Vector2 value = actionReference.action.ReadValue<Vector2>();
            if (value.magnitude > 0.1f && offsetTimer <= 0)
            {
                car.SendMessage("MoveCar", value);
                offsetTimer = 0.01f;
            }
        }
    }

    private void SetGrabbing(SelectEnterEventArgs args)
    {
        grabbing = true;
    }

    private void RemoveGrabbing(SelectExitEventArgs args)
    {
        grabbing = false;
    }
}
