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

        public event EventHandler PatientsCreated;

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
                PatientsCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing patients: {ex.Message}");
                initializedPatients = new List<IPatient>();
            }
        }

        private JsonSerializerSettings ConfigureJsonConverterSettings()
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new IPatientConverter() }
            };
            return settings;
        }

        private string ReadJsonFileToStringFromPath()
        {
            string jsonDataOfIPatients = File.ReadAllText(filePath);
            return jsonDataOfIPatients;
        }
    }
}
