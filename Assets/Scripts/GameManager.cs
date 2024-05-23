using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using Backend;
using System.Linq;

public class GameManager : MonoBehaviour, IPatientBackendAccess
{
	private ParamedicTrainingGameCore gameCore;
	private ISceneSelector sceneSelector;


	public List<PatientInformation> GetAllPatients()
	{
		return gameCore.GetAllPatients();
	}
	private void Awake()
	{

	}

	private void Start()
	{
		sceneSelector = SceneSelectorFactory.GetSceneSelectorInstance();

		List<IGameEventListener> listeners = new List<IGameEventListener>
        {
        };
		gameCore = new ParamedicTrainingGameCore(listeners);
	}

	public void LoadSceneMainMenu()
	{
		sceneSelector.LoadMainMenu();
	}


}
