using UnityEngine;
using System.Threading.Tasks;
using System;

public class SceneManager : MonoBehaviour, ISceneManager
{
    // Singleton instance
    public static SceneManager Instance { get; private set; }

    // Events
    public event Action<string> SceneLoaded;
    public event Action<string> SceneUnloaded;
    
    private void Awake()
    {
        // If the singleton hasn't been initialized yet
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
    }

    public async Task LoadSceneAsync(string sceneName)
    {
        try {
            await Task.Run(() => UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName));
        }
        catch (Exception e)
        {
            Debug.Log($"error : {e.Message}");
        }
    }

    public async Task UnloadSceneAsync(string sceneName)
    {   
        try {
            await Task.Run(() => UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName));
        }
        catch (Exception e)
        {
            Debug.Log($"error : {e.Message}");
        }
    }

    public string GetActiveSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public bool IsSceneLoaded(string sceneName)
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

    public void TransitionToScene(string sceneName, float transitionTime){
        // Add functionality
    }
}
