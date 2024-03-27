using System;
using System.Threading.Tasks;

public interface ISceneManager
{
    // Load a scene by name
    void LoadScene(string sceneName);

    // Unload a scene by name
    void UnloadScene(string sceneName);

    // Asynchronously load a scene by name
    Task LoadSceneAsync(string sceneName);

    // Asynchronously unload a scene by name
    Task UnloadSceneAsync(string sceneName);

    // Get the name of the currently active scene
    string GetActiveSceneName();

    // Check if a scene is loaded
    bool IsSceneLoaded(string sceneName);

    // Transition to a new scene with a fade in/out effect
    void TransitionToScene(string sceneName, float transitionTime);

    // Event triggered when a scene has finished loading
    event Action<string> SceneLoaded;

    // Event triggered when a scene has finished unloading
    event Action<string> SceneUnloaded;
}
