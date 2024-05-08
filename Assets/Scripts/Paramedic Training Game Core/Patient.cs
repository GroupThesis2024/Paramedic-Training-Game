using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Backend
{
    public class Patient : IPatient
    {
        [JsonProperty]
        private string name;

        [JsonProperty]
        int consciousnessLevel;

        [JsonProperty]
        private int classification;

        [JsonProperty]
        private int pulse;

        [JsonProperty]
        private int breathingRate;

        [JsonProperty]
        private List<Condition> conditions = new List<Condition>();

        public string GetName()
        {
            return name;
        }

        public int GetConsciousnessLevel()
        {
            return consciousnessLevel;
        }

        public int GetClassification()
        {
            return classification;
        }

        public void SetClassification(int classification)
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
            Condition conditionToRemove = FindCondition(condition);
            bool conditionIsNotNull = conditionToRemove != null;
            if (conditionIsNotNull)
            {
                RemoveConditionFromList(condition);
            }
            else
            {
                Debug.Write($"Condition not found.");
            }
        }

        private Condition FindCondition(Condition conditionToFind)
        {
            bool conditionsContainConcreteCondition = conditions.Contains(conditionToFind);
            if (conditionsContainConcreteCondition)
            {
                return conditions.Find(conditionToCheck => conditionToCheck == conditionToFind);
            }
            return null;
        }

        private void RemoveConditionFromList(Condition conditionToRemove)
        {
            conditions.Remove(conditionToRemove);
        }
    }
}