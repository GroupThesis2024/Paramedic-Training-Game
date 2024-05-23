using UnityEngine;

public class BackToMenu : MonoBehaviour
{
   public void GoToMenu()
   {
    GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    gameManager.LoadSceneMainMenu();
   }
}
