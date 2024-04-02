using UnityEngine;

namespace SceneSelector
{
    public class SceneManager : MonoBehaviour, ISceneSelector
    {
        public enum SceneName
        {
            XRTest,
            DevTest,
        }

        public void LoadScenarioBusAccident()
        {
            string targetSceneName = SceneName.XRTest.ToString();
            if (IsSceneLoaded(targetSceneName))
            {
                if (targetSceneName == GetActiveSceneName())
                {
                    Debug.LogError($"Error: Scene '{targetSceneName}' is already loaded.");
                }
                else
                {
                    Debug.LogError($"Error: Scene '{targetSceneName}' is already loaded but not active.");
                }
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
            }
        }

        public void LoadMainMenu()
        {
            string targetSceneName = SceneName.DevTest.ToString();
            if (IsSceneLoaded(targetSceneName))
            {
                if (targetSceneName == GetActiveSceneName())
                {
                    Debug.LogError($"Error: Scene '{targetSceneName}' is already loaded.");
                }
                else
                {
                    Debug.LogError($"Error: Scene '{targetSceneName}' is already loaded but not active.");
                }
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
            }
        }

        public string GetActiveSceneName()
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.ToString();
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
    }
}
