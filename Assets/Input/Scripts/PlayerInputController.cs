using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class PlayerInputController : MonoBehaviour
{
    [Header("Input")]
    public InputActionReference rightHandSelectValue;
    public InputActionReference leftHandSelectValue;
    public InputActionReference rightHandSelect;
    public InputActionReference leftHandSelect;
    public InputActionReference leftHandMenu;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to input events (started, performed, canceled) and assign a method to be called
        rightHandSelectValue.action.started += RightSelectValueStarted;
        rightHandSelectValue.action.performed += RightSelectValuePerformed;
        rightHandSelectValue.action.canceled += RightSelectValueCanceled;

        leftHandSelectValue.action.started += LeftSelectValueStarted;
        leftHandSelectValue.action.performed += LeftSelectValuePerformed;
        leftHandSelectValue.action.canceled += LeftSelectValueCanceled;
 
        rightHandSelect.action.started += SelectRightStarted;
     
        leftHandSelect.action.started += SelectLeftStarted;  

        leftHandMenu.action.performed += OpenMenu;
    }

    private void OnEnable()
    {
        rightHandSelectValue.asset.Enable();
        leftHandSelectValue.asset.Enable();

        rightHandSelect.asset.Enable();
        leftHandSelect.asset.Enable();   

        leftHandMenu.asset.Enable();
    }
    private void OnDisable()
    {
        rightHandSelectValue.asset.Disable();
        leftHandSelectValue.asset.Disable();

        rightHandSelect.asset.Disable();
        leftHandSelect.asset.Disable();

        leftHandMenu.asset.Disable();
    }

    private void OnDestroy()
    {
        // Unsubscribe from events 
        rightHandSelectValue.action.started -= RightSelectValueStarted;
        rightHandSelectValue.action.performed -= RightSelectValuePerformed;
        rightHandSelectValue.action.canceled -= RightSelectValueCanceled;

        leftHandSelectValue.action.started -= LeftSelectValueStarted;
        leftHandSelectValue.action.performed -= LeftSelectValuePerformed;
        leftHandSelectValue.action.canceled -= LeftSelectValueCanceled;

        rightHandSelect.action.started -= SelectRightStarted;
        leftHandSelect.action.started -= SelectLeftStarted;
    }
    private void RightSelectValueCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Right Trigger Ended");
    }

    private void RightSelectValuePerformed(InputAction.CallbackContext context)
    {
        // Trigger value action produces a Vector1 value between 0 and 1
        Debug.Log("Right Trigger pressed value: " + context.ReadValue<float>());
    }

    private void RightSelectValueStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Right Trigger Started");
    }

    private void LeftSelectValueCanceled(InputAction.CallbackContext context)
    {
        Debug.Log("Left Trigger Ended");
    }

    private void LeftSelectValuePerformed(InputAction.CallbackContext context)
    {
        // Trigger value action produces a Vector1 value between 0 and 1
        Debug.Log("Left Trigger pressed value: " + context.ReadValue<float>());
    }

    private void LeftSelectValueStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Left Trigger Started");
    }

    private void SelectRightStarted(InputAction.CallbackContext context)
    {

        Debug.Log("Grip Right");
    }

    private void SelectLeftStarted(InputAction.CallbackContext context)
    {

        Debug.Log("Grip Left");
    }

    private void OpenMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Open Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
