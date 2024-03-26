using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField] private InputActionAsset _playerControls;
    [SerializeField] private LayerMask _interactableMask;
    
    private InputAction _select;
    private InputAction _startDialog;
    private GameObject _interactable;

    private InputActionMap _leftHandInteraction;
    private InputActionMap _rightHandInteraction;




    private void Start()
    {
        // Get left and right hand interaction maps
        _leftHandInteraction = _playerControls.FindActionMap("XRI LeftHand Interaction");
        _rightHandInteraction = _playerControls.FindActionMap("XRI RightHand Interaction");
      
        // Get the Select action (GripButton) into local InputAction variables
        _select = _leftHandInteraction.FindAction("Select");
        _startDialog = _rightHandInteraction.FindAction("Select");

        // Add methods to list of subscriptions that get called when there is an action
        _select.performed += OnSelect;
        _startDialog.performed += OnStartDialog;

        _select.Enable();
        _startDialog.Enable();

    }

    public void OnHoverEnteredPatient()
    {
        Debug.Log("Interact with patient");
    }

    public void OnHoverExitedPatient()
    {
        Debug.Log("Interaction ended");
    }

    private void OnSelect(InputAction.CallbackContext context)
    {
        // TODO: check that player can select this patient (e.g. they are 
        // close enough or have touched the patient and patient hasn't been treated already)
        Debug.Log("Select");
    }

    private void OnStartDialog(InputAction.CallbackContext context)
    {
        // TODO: check that dialog can be started (patient has been selected)
        Debug.Log("Start dialog");
    }
}
