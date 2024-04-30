using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonCollision : MonoBehaviour
{
    public Toggle toggle; // Reference to the toggle UI element

    // OnTriggerEnter is called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Toggle the state of the button
            toggle.isOn = !toggle.isOn;
        }
    }
}
