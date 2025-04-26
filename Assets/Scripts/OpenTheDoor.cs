using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject door;
    private Animator animator;
    private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = door.GetComponent<Animator>();
        XRSimpleInteractable simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSelectEntered(SelectEnterEventArgs eventArgs)
    {
        opened = !opened;
        if (opened)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            animator.SetTrigger("Close");    
        }
    }
}
