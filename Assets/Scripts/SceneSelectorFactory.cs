using UnityEngine;

namespace SceneSelector
{
    public class SceneSelectorFactory
    {
        public ISceneSelector GetSceneSelector()
        {
            // Create the scene selector
            GameObject sceneSelectorObject = new GameObject("SceneSelector");

            // Attach the SceneManager script to the GameObject
            SceneManager sceneSelector = sceneSelectorObject.AddComponent<SceneSelector.SceneManager>();

            return sceneSelector;
        }
    }
}