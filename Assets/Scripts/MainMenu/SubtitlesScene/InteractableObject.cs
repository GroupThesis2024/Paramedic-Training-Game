using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
       private bool cubeInteracted = false; // Flag to track whether the player has interacted with the cube
       private SubtitlesManager subtitlesManager;
       public string subtitleText; 
       //Text example: This is cube! To interact with it,press trigger button!
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !cubeInteracted)
        {
            // Display subtitles when colliding with the player
            SubtitlesManager subtitlesManager = SubtitlesManager.Instance;
            subtitlesManager.DisplaySubtitle(subtitleText);

        }
    }
     // Method to set the cubeInteracted flag
    public void SetCubeInteracted(bool value)
    {
        cubeInteracted = value;
    }

}
