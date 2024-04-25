using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerHead : MonoBehaviour
{
 private Transform playerCameraTransform; // Reference to the player's camera transform
 private Vector3 offsetFromCamera = new Vector3(0f, -0.4f, 1f); //Reference to the position of the player's camera

    void Start()
    {
        // Find the player's camera by tag
        GameObject  playerCameraObject = GameObject.Find("Player Camera");
        if (playerCameraObject != null)
        {
            playerCameraTransform = playerCameraObject.transform;
            if (playerCameraTransform == null)
            {
                Debug.LogError("Transform component not found on the object tagged as 'Player Camera'.");
            }
        }
        else
        {
            Debug.LogError("Object tagged as 'Player Camera' not found in the scene.");
        }
    }

    void Update()
    {
        if (playerCameraTransform != null)
        {
            // Calculate the direction from the subtitles to the player's camera
            Vector3 targetPosition = playerCameraTransform.position + playerCameraTransform.TransformDirection(offsetFromCamera);
            // Ensure the subtitles face the player's camera
            transform.position = targetPosition;
            // Ensure the subtitles face the player's camera
            transform.rotation = Quaternion.LookRotation(playerCameraTransform.forward);
        }
    }

}
