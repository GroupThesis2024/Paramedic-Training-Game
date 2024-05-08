using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private ParamedicTrainingGameCore gameCore;

	private void Awake()
	{
		gameCore = new ParamedicTrainingGameCore();
	}

	private void Start()
	{

	}
}
