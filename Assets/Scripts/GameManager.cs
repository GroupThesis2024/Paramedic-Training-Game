using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using Backend;

public class GameManager : MonoBehaviour
{
	private ParamedicTrainingGameCore gameCore;
	List<EventHandler<CustomEventArgs>> eventHandlers = new List<EventHandler<CustomEventArgs>>();

	private void Awake()
	{
		gameCore = new ParamedicTrainingGameCore(eventHandlers);
	}

	private void Start()
	{

	}
}
