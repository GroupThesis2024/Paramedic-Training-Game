using UnityEngine;

public class PatientSpawnPoint : MonoBehaviour
{
    public bool IsSitting;

    public float GetHeightFromSurface()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            return hit.point.y - transform.position.y; // Negative ray cast result
        }
        else
        {
            return 0f; // Default offset if no collision is detected
        }
    }
}