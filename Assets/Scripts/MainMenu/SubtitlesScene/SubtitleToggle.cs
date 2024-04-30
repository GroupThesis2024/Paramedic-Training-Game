using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleToggle : MonoBehaviour
{
   public Toggle subtitleToggle;

    private void Start()
    {
        // Initialize toggle state based on saved preference
        subtitleToggle.isOn = SubtitlesController.subtitlesEnabled;
    }

    public void ToggleSubtitles()
    {
        SubtitlesController subtitlesController = FindObjectOfType<SubtitlesController>();
        if (subtitlesController != null)
        {
            // Toggle subtitles and save preference
            subtitlesController.ToggleSubtitles(subtitleToggle.isOn);
            subtitlesController.SaveSubtitlePreference();
        }
    }
}
