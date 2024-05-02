using System.Collections.Generic;

namespace Backend
{
    public class Patient : IPatient
    {
        private string name;
        private byte classification;
        private int pulse;
        private int breathingRate;
        private List<Condition> conditions = new List<Condition>();

        public string GetName()
        {
            return name;
        }

        public byte GetClassification()
        {
            return classification;
        }

        public void SetClassification(byte classification)
        {
            this.classification = classification;
        }

        public int GetPulse()
        {
            return pulse;
        }

        public int GetPulseAtWrist()
        {
            return pulse; //IF KEPT, SOME OTHER LOGIC NEEDED
        }

        public int GetBreathingRate()
        {
            return breathingRate;
        }

        public List<Condition> GetConditions()
        {
            return conditions;
        }

        public void AddCondition(Condition condition)
        {
            conditions.Add(condition);
        }

        public void RemoveCondition(Condition condition)
        {
            Condition conditionToFind = conditions.Find(x => x == condition);
            conditions.Remove(conditionToFind);
        }
    }
}