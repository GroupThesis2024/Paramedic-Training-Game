using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Patient : MonoBehaviour
{
	[Tooltip("Patient interaction menu instance, which to toggle visible/hidden.")]
	public GameObject patientInteractionMenu;
	public Transform patientInteractionMenuParent;

	[Tooltip("Distance at which player needs to be to show the patient interaction menu.")]
	[Range(0f, 100f)]
	public float playerProximityDistanceToShowInteractionMenu = 5f;


	private Transform playerInstance;
	private bool playerIsWithinProximity = false;


    void Start()
    {
		GetPlayerTransformReference();
        ClosePatientInteractionMenu();
    }

	private void GetPlayerTransformReference()
	{
		playerInstance = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}

	public void ClosePatientInteractionMenu()
	{
		patientInteractionMenu.SetActive(false);
	}

	public void OpenPatientInteractionMenu()
	{
		patientInteractionMenu.SetActive(true);
	}

	void Update()
    {
		UpdatePlayerProximityStatus();
		UpdatePatientMenuVisibilityStatusBasedOnPlayerProximity();
		FaceInteractionMenuParentTowardsMainCamera();
    }

	private void UpdatePlayerProximityStatus()
	{
		if (PlayerInstanceExists())
		{
			float distanceToPlayer = Vector3.Distance(
					this.transform.position, playerInstance.position);
			playerIsWithinProximity = distanceToPlayer < playerProximityDistanceToShowInteractionMenu;				
		}
	}

	private bool PlayerInstanceExists()
	{
		return playerInstance != null;
	}

	private void UpdatePatientMenuVisibilityStatusBasedOnPlayerProximity()
	{
		if(playerIsWithinProximity)
		{
			OpenPatientInteractionMenu();
		}
		else
		{
			ClosePatientInteractionMenu();
		}
	}

	private void FaceInteractionMenuParentTowardsMainCamera()
	{
		patientInteractionMenuParent.LookAt(Camera.main.transform);
	}
}