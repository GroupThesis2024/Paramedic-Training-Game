using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SubtitlesManager : MonoBehaviour
{
     public static SubtitlesManager Instance;

    public GameObject subtitlesUI;
    public TextMeshProUGUI subtitleText;
    private bool subtitlesVisible = false;
    private float subtitleDuration = 4f;
    private float subtitleTimer = 0f;

    private HashSet<GameObject> disabledObjects = new HashSet<GameObject>(); // Keep track of objects with disabled subtitles

    void Awake()
    {
        Instance = this;
        // Ensure subtitles UI is initially disabled
        subtitlesUI.SetActive(false);
    }

    void Update()
    {
        // Update subtitle timer
        if (subtitlesVisible) 
        {
            subtitleTimer += Time.deltaTime;
            if (subtitleTimer >= subtitleDuration)
            {
                // Hide subtitles after duration
                HideSubtitle();
            }
        }
    }

    public void DisplaySubtitle(string text)
    {
     
        // Show subtitles UI
        subtitlesUI.SetActive(true);
        // Set subtitle text
        subtitleText.text = text;
        // Reset timer
        subtitleTimer = 0f;
        // Set subtitles as visible
        subtitlesVisible = true;
        
    }

    public void HideSubtitle()
    {
        // Hide subtitles UI
        subtitlesUI.SetActive(false);
        // Set subtitles as not visible
        subtitlesVisible = false;
    }

   public void DisableAllSubtitles(GameObject obj)
    {
        disabledObjects.Add(obj);
    }

    public bool AreSubtitlesDisabledForObject(GameObject obj)
    {
        // Check if the object's subtitles are disabled
        return disabledObjects.Contains(obj);
    }
}

