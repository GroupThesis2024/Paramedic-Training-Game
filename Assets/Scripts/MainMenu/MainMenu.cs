using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void OnClick_Settings(){

    MenuManager.OpenMenu(Menu.SETTINGS_MENU, gameObject);

   }
}
