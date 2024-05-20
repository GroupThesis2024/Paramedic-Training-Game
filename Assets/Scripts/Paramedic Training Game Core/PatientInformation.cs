using System.Collections.Generic;

namespace Backend
{
    public struct PatientInformation
    {
        public string name { get; set; }
        public int trueClassification { get; set; }
        public int playerGivenClassification { get; set; }
        public int consciousnessLevel { get; set; }
        public float heartRate { get; set; }
        public float heartRateAtWrist { get; set; }
        public float breathingRate { get; set; }
        public List<Condition> conditions { get; set; }
    }
}