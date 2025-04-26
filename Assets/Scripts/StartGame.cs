using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGame : MonoBehaviour
{
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable simpleInteractable = GetComponent<XRSimpleInteractable>();
        simpleInteractable.selectEntered.AddListener(args =>
        {
            game.SendMessage("StartGame", SendMessageOptions.DontRequireReceiver);
        });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
