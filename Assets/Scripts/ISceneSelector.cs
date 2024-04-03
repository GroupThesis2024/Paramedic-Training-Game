namespace SceneSelector
{
    public interface ISceneSelector
    {
        void LoadScenarioBusAccident();

        void LoadMainMenu();

        string GetActiveSceneName();

        bool IsSceneLoaded(string sceneName);
    }
}
