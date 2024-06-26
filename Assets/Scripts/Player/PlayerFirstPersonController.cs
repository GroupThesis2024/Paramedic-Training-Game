using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Responsible for reading inputs and controlling the player instance like a first person character.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerFirstPersonController : MonoBehaviour
{
	[Header("Rquired References")]
	[SerializeField]
	private Camera playerCamera;

	[SerializeField]
	private GameObject playerHand;

	[Space]

	[Header("Movement Settings")]
	[SerializeField, Range(10f,500f)]
	private float moveSpeed = 100f;

	[Space]

	[Header("Look Settings")]
	[SerializeField, Range(.01f, 3f)]
	private float lookSensitivity = 1f;

	[Space]

	[Header("Hand Settings")]
	[SerializeField, Range(0f, 10f)]
	private float handMaxReach = 2f;

	[SerializeField, Range(0.05f, 1f)]
	private float handMoveSensitivity = .1f;


	private Rigidbody playerRigidbody;

	private Vector2 moveVector = Vector2.zero;
	private Vector2 lookDelta = Vector2.zero;
	/// <summary>A 1D vector value between -1 and 1.</summary>
	private float handMoveDelta = 0f;
	private float handStartingPositionZ;

	private bool isCursorHiddenAndLocked = false;


	private void Awake()
	{
		TryToGetPlayerRigidbody();
		EnsureRequiredReferencesAreAssigned();
	}

	private void TryToGetPlayerRigidbody()
	{
		playerRigidbody = GetComponent<Rigidbody>();
		if (playerRigidbody == null ) 
		{
			throw new NullReferenceException("'Rigidbody' component is required by this script. " +
				"Did you remember to add it in the inspector?");
		}
	}

	private void EnsureRequiredReferencesAreAssigned()
	{
		EnsurePlayerCameraReferenceIsAssigned();
		EnsurePlayerHandReferenceIsAssigned();
	}

	private void EnsurePlayerCameraReferenceIsAssigned()
	{
		if (playerCamera == null)
		{
			ThrowRequiredReferenceIsNotAssignedError("Player Camera");
		}
	}

	private void EnsurePlayerHandReferenceIsAssigned()
	{
		if (playerHand == null)
		{
			ThrowRequiredReferenceIsNotAssignedError("Player Hand");
		}
	}

	private void ThrowRequiredReferenceIsNotAssignedError(string nameOfRequiredReference)
	{
		throw new UnassignedReferenceException("A reference to '" + nameOfRequiredReference + "' is required to run this script. " + 
			"Did you remember to add it in the inspector?");
	}

	private void Start()
	{
		LockPlayerRigidbodyRotationInAllAxis();
		AssignStartingPositionForPlayerHand();
		HideAndLockCursor();
	}

	private void LockPlayerRigidbodyRotationInAllAxis()
	{
		playerRigidbody.constraints = 
			RigidbodyConstraints.FreezeRotationX |
			RigidbodyConstraints.FreezeRotationY |
			RigidbodyConstraints.FreezeRotationZ;
	}

	private void AssignStartingPositionForPlayerHand()
	{
		handStartingPositionZ = GetPlayerHandLocalPositionZ();
	}

	private float GetPlayerHandLocalPositionZ()
	{
		return playerHand.transform.localPosition.z;
	}

	private void FixedUpdate()
	{
		Move();
		Look();
	}

	private void Move()
	{
		Vector3 worldOrientedMoveVector = new Vector3(moveVector.x, 0f, moveVector.y);
		playerRigidbody.AddRelativeForce( worldOrientedMoveVector * moveSpeed );
	}

	private void Look()
	{
		ApplyHorizontalLookDeltaToThisObject();
		ApplyVerticalLookDeltaToPlayerCamera();
	}

	private void ApplyHorizontalLookDeltaToThisObject()
	{
		float sensitivityCorrectedHorizontalLookDelta = lookDelta.x * lookSensitivity;
		this.transform.Rotate(0f, sensitivityCorrectedHorizontalLookDelta, 0f);
	}

	private void ApplyVerticalLookDeltaToPlayerCamera()
	{
		float sensitivityCorrectedVerticalLookDelta = -lookDelta.y * lookSensitivity;
		float currentCameraAngleX = playerCamera.transform.localRotation.eulerAngles.x;
		float newCameraRotationX = currentCameraAngleX + sensitivityCorrectedVerticalLookDelta;
		Quaternion newCameraRotation = Quaternion.Euler(newCameraRotationX, 0f, 0f);

		playerCamera.transform.localRotation = newCameraRotation;
	}

	private void MoveHandAlongAxisZ()
	{
		float currentHandPositionZ = GetPlayerHandLocalPositionZ();
		float sensitivityCorrectedHandMoveDelta = handMoveDelta * handMoveSensitivity;
		float newHandPositionZ = currentHandPositionZ + sensitivityCorrectedHandMoveDelta;

		newHandPositionZ = ClampBetweenHandStartingPositionAndMaxReachPosition(newHandPositionZ);

		Vector3 newHandPosition = playerHand.transform.localPosition;
		newHandPosition.z = newHandPositionZ;

		playerHand.transform.localPosition = newHandPosition;
	}

	private float ClampBetweenHandStartingPositionAndMaxReachPosition(float valueToClampFrom)
	{
		float handMaxReachPositionZ = handStartingPositionZ + handMaxReach;
		return Math.Clamp(valueToClampFrom, handStartingPositionZ, handMaxReachPositionZ);
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnMove(InputAction.CallbackContext inputContext)
	{
		moveVector = inputContext.ReadValue<Vector2>();
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnLook(InputAction.CallbackContext inputContext) 
	{ 
		lookDelta = inputContext.ReadValue<Vector2>();
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnMoveHand(InputAction.CallbackContext inputContext)
	{
		handMoveDelta = inputContext.ReadValue<float>();
		MoveHandAlongAxisZ();
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnGrab(InputAction.CallbackContext inputContext)
	{
		// TODO: Not implemented, will be addressed in a later issue
		throw new NotImplementedException("OnGrab() action has not been implemented for player yet.");
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnInteract(InputAction.CallbackContext inputContext)
	{
		// TODO: Not implemented, will be addressed in a later issue
		throw new NotImplementedException("OnInteract() action has not been implemented for player yet");
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnUISelect(InputAction.CallbackContext inputContext)
	{
		// TODO: Not implemented, will be addressed in a later issue
		throw new NotImplementedException("OnUISelect() action has not been implemented for player yet.");
	}

	/// <summary>
	/// Manually hooked method (in the inspector) to a binding in <see cref="PlayerInput"/> component. 
	/// Gets called once every time the corresponding input value changes.
	/// </summary>
	/// <param name="inputContext">Callback information provided by <see cref="PlayerInput"/>,
	/// for reading values generated by hardware, and etc..</param>
	public void OnHideAndLockCursor(InputAction.CallbackContext inputContex)
	{
		ToggleHideAndLockCursorState();
	}

	private void ToggleHideAndLockCursorState()
	{
		if (isCursorHiddenAndLocked)
		{
			UnhideAndUnlockCursor();
		}
		else
		{
			HideAndLockCursor();
		}
	}

	private void HideAndLockCursor()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		isCursorHiddenAndLocked = true;
	}

	private void UnhideAndUnlockCursor()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		isCursorHiddenAndLocked = false;
	}
}