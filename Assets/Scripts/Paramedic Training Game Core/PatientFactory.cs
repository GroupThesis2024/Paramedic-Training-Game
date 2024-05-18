using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Backend
{
    public class PatientFactory
    {
        private static readonly string filePath = Path.Combine(
            Environment.CurrentDirectory,
            "Assets/Scripts/Paramedic Training Game Core",
            "patientData.json"
        );

        private List<PatientInformation> initializedPatients;

        public List<PatientInformation> GetAllPatients()
        {
            return initializedPatients;
        }

        public void InitializePatients()
        {
            InitializePatientsFromJson();
        }

        private void InitializePatientsFromJson()
        {
            try
            {
                string jsonAsString = ReadJsonFileToStringFromPath();
                initializedPatients = JsonConvert.DeserializeObject<List<PatientInformation>>(jsonAsString);
            }
            catch (Exception ex)
            {
                Debug.Log($"Error initializing patients: {ex.Message}");
                initializedPatients = new List<PatientInformation>();
            }
        }

        private string ReadJsonFileToStringFromPath()
        {
            string jsonDataOfIPatients = File.ReadAllText(filePath);
            return jsonDataOfIPatients;
        }
    }
}
