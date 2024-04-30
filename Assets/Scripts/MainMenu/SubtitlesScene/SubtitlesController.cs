using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesController : MonoBehaviour
{
   public static bool subtitlesEnabled = true;

    // Load player's choice from PlayerPrefs
    private void Awake()
    {
        subtitlesEnabled = PlayerPrefs.GetInt("SubtitlesEnabled", 1) == 1;
    }

    // Enable/disable subtitles based on player's choice
    private void Start()
    {
        ToggleSubtitles(subtitlesEnabled);
    }

    // Toggle subtitles on/off
    public void ToggleSubtitles(bool isEnabled)
    {
        subtitlesEnabled = isEnabled;
        // Code to enable/disable subtitles globally in your game
    }

    // Save player's choice to PlayerPrefs
    public void SaveSubtitlePreference()
    {
        PlayerPrefs.SetInt("SubtitlesEnabled", subtitlesEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }
}
