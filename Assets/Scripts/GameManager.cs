using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using Backend;
using System.Linq;

public class GameManager : MonoBehaviour
{
	private ParamedicTrainingGameCore gameCore;
	private ISceneSelector sceneSelector;

	private PatientBackendAccessImplementation patientBackendAccessImplementation;
	private IPatientBackendAccess patientBackendAccess;


	private void Awake()
	{
		InitializeGameCore();
		InitializePatientBackendAccess();
	}

	private void InitializeGameCore()
    {
		List<IGameEventListener> emptyListOfListeners = new List<IGameEventListener> ();
		gameCore = new ParamedicTrainingGameCore(emptyListOfListeners);
    }

	private void InitializePatientBackendAccess()
    {
		patientBackendAccessImplementation = new PatientBackendAccessImplementation(gameCore);
		patientBackendAccess = patientBackendAccessImplementation as IPatientBackendAccess;

    }

    private class PatientBackendAccessImplementation : IPatientBackendAccess
    {
		ParamedicTrainingGameCore gameCoreInstance;

		public PatientBackendAccessImplementation(ParamedicTrainingGameCore gameCoreInstance)
        {
            this.gameCoreInstance = gameCoreInstance;
        }

        public List<PatientInformation> GetAllPatients()
        {
			return gameCoreInstance.GetAllPatients();
        }
    }

	public IPatientBackendAccess GetPatientBackendAccess()
	{
		return patientBackendAccess;
	}

	private void Start()
	{
		sceneSelector = SceneSelectorFactory.GetSceneSelectorInstance();
	}

	public void LoadSceneMainMenu()
	{
		sceneSelector.LoadMainMenu();
	}


}
