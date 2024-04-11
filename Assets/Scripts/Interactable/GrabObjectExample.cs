using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjectExample : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference triggerReference; //Optional input action reference
    public Transform attachPoint;

    private bool canGrab = false;
    private bool objectGrabbed = false; 
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        if(triggerReference != null)
        {
            triggerReference.action.started += TriggerStarted;
            triggerReference.action.canceled += TriggerCanceled;
        }
    }

    private void OnEnable()
    {
        if (triggerReference != null)
        {
            triggerReference.asset.Enable();
        }
    }

    private void OnDisable()
    {
        if (triggerReference != null)
        {
            triggerReference.asset.Disable();
        }
    }

    private void OnDestroy()
    {
        if (triggerReference != null)
        {
            triggerReference.action.started -= TriggerStarted;
            triggerReference.action.canceled -= TriggerCanceled;
        }
    }

    private void TriggerCanceled(InputAction.CallbackContext context)
    {
        HandleRelease();    
    }

    private void TriggerStarted(InputAction.CallbackContext context)
    {
        HandleGrab();
    }

    private void HandleGrab()
    {
        if (canGrab && interactable != null && !objectGrabbed)
        {
            interactable.Grab(attachPoint);
            objectGrabbed = true;
        }
    }

    private void HandleRelease()
    {
        if (interactable != null && objectGrabbed)
        {
            interactable.Release();
            objectGrabbed = false;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            HandleGrab();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            HandleRelease();
        }  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable" && !objectGrabbed)
        {
            Debug.Log("Can Grab " + other.gameObject.name);
            canGrab = true;
            interactable = other.GetComponent<Interactable>();
           
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            Debug.Log("Trigger exit");
            canGrab = false;
            
        }
    }
}
