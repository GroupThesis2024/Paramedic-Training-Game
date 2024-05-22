using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMainGamePauseMenuManager : MonoBehaviour
{
	public GameObject menuObject;
	public Button endGameButton;
	public Button hideMenuButton;
	public InputActionProperty toggleMenuVisibilityAction;

	private GameManager gameManager;
	private bool menuIsVisible = false;


    void Start()
    {
        GetGameManagerReference();
		ConfigureButtonOnClickListeners();
		ConfigureInputActionListeners();
		HideMenu();
    }

	private void GetGameManagerReference()
	{
		gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}

	private void ConfigureButtonOnClickListeners()
	{
		endGameButton.onClick.AddListener(EndGame);
		hideMenuButton.onClick.AddListener(HideMenu);
	}

	private void ConfigureInputActionListeners()
	{
		toggleMenuVisibilityAction.action.performed += context =>
		{
			ToggleMenuVisibility();
		};
	}

	private void EndGame()
	{
		gameManager.LoadSceneMainMenu();
	}

	private void ShowMenu()
	{
		menuIsVisible = true;
		menuObject.SetActive(true);
	}

	private void HideMenu()
	{
		menuIsVisible = false;
		menuObject.SetActive(false);
	}

	private void ToggleMenuVisibility()
	{
		if (menuIsVisible)
		{
			HideMenu();
		}
		else
		{
			ShowMenu();
		}
	}
}