using System.Collections.Generic;

namespace Backend
{
	public class ParamedicTrainingGameCore
	{
		private List<PatientInformation> patients;

		public ParamedicTrainingGameCore(List<IGameEventListener> listeners)
		{
			PatientFactory patientFactory = new PatientFactory();
			patientFactory.InitializePatients();
			patients = patientFactory.GetAllPatients();
			InformEventListeners(listeners);
		}

		public List<PatientInformation> GetAllPatients()
		{
			return patients;
		}

		private void InformEventListeners(List<IGameEventListener> listeners)
		{
			foreach (IGameEventListener eventListener in listeners)
			{
				eventListener.OnGameInitialized();
			}
		}
	}
}