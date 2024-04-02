namespace SceneSelector
{
    public interface ISceneSelector
    {
        // Load explicit scene: Bus Accident Scene
        void LoadScenarioBusAccident();

        // Load explicit scene: Main menu
        void LoadMainMenu();

        // Get the name of the currently active scene
        string GetActiveSceneName();

        // Check if a scene is loaded
        bool IsSceneLoaded(string sceneName);
    }
}
