using UnityEngine;

public class SpawnPointFinder
{
    public SpawnPointFinder()
    {
        GetAllPatientSpawnPointsInScene()
    }

    public List<PatientSpawnPoint> GetAllPatientSpawnPointsInScene()
    {
        PatientSpawnPoint[] patientSpawnPoints = GameObject.FindGameObjectsWithTag("PatientSpawnPoint");
        return patientSpawnPoints;
    }
}