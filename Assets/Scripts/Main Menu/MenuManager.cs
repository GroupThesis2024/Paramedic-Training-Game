using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	private ISceneSelector sceneSelector;


    void Start()
    {
        GetSceneSelectorInstance();
    }

	private void GetSceneSelectorInstance()
	{
		sceneSelector = SceneSelectorFactory.GetSceneSelectorInstance();
	}

	public void LoadSceneScenarioBusAccident()
	{
		sceneSelector.LoadScenarioBusAccident();
	}

	public void QuitApplication()
	{
		sceneSelector.QuitApplication();
	}
}