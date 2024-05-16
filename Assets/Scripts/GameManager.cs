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

	private void Awake()
	{

	}

	private void Start()
	{
		List<IGameEventListener> listeners = new List<IGameEventListener>
        {
        };
		gameCore = new ParamedicTrainingGameCore(listeners);
	}
}
