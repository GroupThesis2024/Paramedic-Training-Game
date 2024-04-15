using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using static class
public static class MenuManager
{

    public static bool IsInitialised { get; private set;} 

    
  public static GameObject mainMenuView, settingsMenu;

  public static void Init(){

    GameObject canvasMenu = GameObject.Find ("MainMenu");
    mainMenuView = canvasMenu.transform.Find ("MainMenuView").gameObject;
    settingsMenu = canvasMenu.transform.Find ("Settings").gameObject;

    IsInitialised = true;
  }  

public static void OpenMenu( Menu menu, GameObject callingMenu ){

    if(!IsInitialised)
    Init();

    switch( menu ){
      case Menu.MAIN_MENU_VIEW:
        mainMenuView.SetActive( true );
        break;
      case Menu.SETTINGS_MENU:
        settingsMenu.SetActive( true );
        break;
    }

    callingMenu.SetActive( false );
  }

}


