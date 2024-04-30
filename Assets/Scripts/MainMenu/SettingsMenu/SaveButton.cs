using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveButton : MonoBehaviour{
    public SubtitleToggle subtitleToggle; // Reference to the SubtitleToggle script

    // OnTriggerEnter is called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Save changes (e.g., subtitles) before exiting play mode
            subtitleToggle.ToggleSubtitles(); // Save changes

            // Exit play mode and transition to the game scene
            SceneManager.LoadScene("SubtitlesDemo");
        }
    }
}

