using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Backend
{
    public class PatientFactory
    {
        private static string filePath = Path.Combine(
            Environment.CurrentDirectory,
            "Assets/Scripts/Paramedic Training Game Core",
            "patientData.json"
        );

        public List<IPatient> GetAllPatients()
        {
            JsonSerializerSettings settings = ConfigureJsonConverterSettings();
            string jsonAsString = ReadJsonFileToStringFromPath();
            List<IPatient> patientsList = JsonConvert.DeserializeObject<List<IPatient>>(jsonAsString, settings);
            return patientsList;
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
