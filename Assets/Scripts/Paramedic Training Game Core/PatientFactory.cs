using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Backend
{
    public class PatientFactory
    {
        private static readonly string filePath = Path.Combine(
            Environment.CurrentDirectory,
            "Assets/Scripts/Paramedic Training Game Core",
            "patientData.json"
        );

        private List<IPatient> initializedPatients;

        public List<IPatient> GetAllPatients()
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
                JsonSerializerSettings settings = ConfigureJsonConverterSettings();
                initializedPatients = JsonConvert.DeserializeObject<List<IPatient>>(jsonAsString, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing patients: {ex.Message}");
                initializedPatients = new List<IPatient>();
            }
        }

        private string ReadJsonFileToStringFromPath()
        {
            string jsonDataOfIPatients = File.ReadAllText(filePath);
            return jsonDataOfIPatients;
        }

        private JsonSerializerSettings ConfigureJsonConverterSettings()
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new IPatientConverter() }
            };
            return settings;
        }
    }
}
