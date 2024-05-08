using System.Collections.Generic;
using Newtonsoft.Json;

namespace Backend
{
	public interface IPatient
	{
		string GetName();

		int GetConsciousnessLevel();

		int GetClassification();

		void SetClassification(int classification);

		int GetPulse();

		int GetPulseAtWrist();

		int GetBreathingRate();

		List<Condition> GetConditions();

		void AddCondition(Condition condition);

		void RemoveCondition(Condition condition);
	}
}
