using UnityEngine;

namespace SceneSelector
{
    public class SceneSelectorFactory
    {
        public ISceneSelector GetSceneSelector()
        {
            // Create the scene selector
            var sceneSelectorObject = new GameObject("SceneSelector");

            // Attach the SceneManager script to the GameObject
            var sceneSelector = sceneSelectorObject.AddComponent<SceneSelector.SceneManager>();

            return sceneSelector;
        }
    }
}
