using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPatientBackendAccess
{
    public List<Backend.PatientInformation> GetAllPatients();
}
