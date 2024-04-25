using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
       public string subtitleText; 
       //Text example: This is cube! To interact with it,press trigger button!
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Display subtitles when colliding with the player
            SubtitlesManager subtitlesManager = SubtitlesManager.Instance;
            subtitlesManager.DisplaySubtitle(subtitleText);
        }
    }

}
