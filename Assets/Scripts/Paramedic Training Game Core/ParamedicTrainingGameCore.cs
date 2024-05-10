using System;
using System.Collections.Generic;


namespace Backend
{
	public class ParamedicTrainingGameCore
	{
		private readonly List<EventHandler<CustomEventArgs>> eventHandlers;

		private PatientFactory patientFactory;

		public event EventHandler<CustomEventArgs> PatientsInitializedSuccesfullyEvent;

		public ParamedicTrainingGameCore(List<EventHandler<CustomEventArgs>> eventHandlers)
		{
			this.eventHandlers = eventHandlers;
			SubscribeEventHandlersFromList();
			SubscribeToPatientFactoryAndInitializePatients();
			UnSubscribeEventHandlersFromList();
		}

		private void SubscribeEventHandlersFromList()
		{
			foreach (EventHandler<CustomEventArgs> eventHandler in eventHandlers)
			{
				PatientsInitializedSuccesfullyEvent += eventHandler;
			}
		}

		private void SubscribeToPatientFactoryAndInitializePatients()
		{
			patientFactory = new PatientFactory();
			patientFactory.PatientsCreated += OnPatientsCreated;
			patientFactory.InitializePatients();
			patientFactory.PatientsCreated -= OnPatientsCreated;
		}

		private void OnPatientsCreated(object sender, EventArgs e)
		{
			NotifySubscribersPatientsCreated();
		}

		private void NotifySubscribersPatientsCreated()
		{
			foreach (Delegate delegateMethod in PatientsInitializedSuccesfullyEvent.GetInvocationList())
			{
				try
				{
					delegateMethod.DynamicInvoke(this, new CustomEventArgs(patientFactory));
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception caught: {ex.Message}");
				}
			}
		}

		private void UnSubscribeEventHandlersFromList()
		{
			foreach (EventHandler<CustomEventArgs> eventHandler in eventHandlers)
			{
				PatientsInitializedSuccesfullyEvent -= eventHandler;
			}
		}
	}
}