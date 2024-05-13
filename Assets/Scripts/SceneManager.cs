using UnityEngine;

public class SceneManager : MonoBehaviour, ISceneSelector
{
	private const string scenarioBusAccidentSceneName = "ScenarioBusAccident";
	private const string mainMenuSceneName = "MainMenu";

    public void LoadScenarioBusAccident()
    {
        LoadScene(scenarioBusAccidentSceneName);
    }

    public void LoadMainMenu()
    {
        LoadScene(mainMenuSceneName);
    }

	public void QuitApplication()
	{
		Application.Quit();
	}

    private void LoadScene(string targetSceneName)
    {
        if (IsSameSceneLoaded(targetSceneName))
        {
            Debug.LogError(
                $"Error: Scene '{targetSceneName}' is already loaded{(targetSceneName == GetActiveSceneName() ? "." : " but not active.")}"
            );
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
        }
    }
    private bool IsSameSceneLoaded(string targetSceneName)
    {
        return IsSceneLoaded(targetSceneName) && targetSceneName == GetActiveSceneName();
    }

    private bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetSceneAt(i).name == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    private string GetActiveSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString();
    }
}