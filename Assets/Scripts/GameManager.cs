using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GameCore gameCore;

	private void Awake()
	{
		gameCore = new GameCore();
	}

	private void Start()
	{
		
	}
}
