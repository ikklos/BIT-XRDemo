using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CutBall : MonoBehaviour
{
    private Action CuttedHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            Cutted();
        }
    }
    void Cutted()
    {
        CuttedHandler?.Invoke();
        Destroy(this.gameObject);
    }

    public void SetCuttedHandler(Action handler)
    {
        this.CuttedHandler = handler;
    }
}
