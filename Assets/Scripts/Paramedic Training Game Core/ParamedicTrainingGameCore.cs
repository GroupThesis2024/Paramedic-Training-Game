using System.Collections.Generic;
using UnityEngine;

namespace Backend
{
	public class ParamedicTrainingGameCore
	{
		public ParamedicTrainingGameCore(List<IGameEventListener> listeners)
		{
			PatientFactory patientFactory = new PatientFactory();
			patientFactory.InitializePatients();
			InformEventListeners(listeners);
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