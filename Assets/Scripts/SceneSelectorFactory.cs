using UnityEngine;

public static class SceneSelectorFactory
{
	private const string sceneManagerTag = "SceneManager";

    public static ISceneSelector GetSceneSelectorInstance()
    {
		SceneManager existingSceneManager = TryToGetExistingSceneManagerInScene();
		bool sceneManagerExistsInScene = existingSceneManager != null;
		if (sceneManagerExistsInScene)
		{
			return existingSceneManager;
		}
		else 
		{
			return InstantiateNewSceneManageToScene();
		}
    }

	private static SceneManager TryToGetExistingSceneManagerInScene()
	{
		GameObject sceneManagerObject = GameObject.FindWithTag(sceneManagerTag);
		bool sceneManagerObjectDoesNotExists = sceneManagerObject == null;
		if (sceneManagerObjectDoesNotExists) 
		{
			return null;
		}

		SceneManager sceneManagerComponent = sceneManagerObject.GetComponent<SceneManager>();
		bool sceneManagerComponentDoesNotExists = sceneManagerComponent == null;
		if (sceneManagerComponentDoesNotExists)
		{
			return null;
		}

		return sceneManagerComponent;
	}

	private static SceneManager InstantiateNewSceneManageToScene()
	{
		GameObject sceneSelectorGameObject = new GameObject("SceneSelector");
		sceneSelectorGameObject.tag = sceneManagerTag;
		SceneManager sceneManagerComponent = sceneSelectorGameObject.AddComponent<SceneManager>();

		return sceneManagerComponent;
	}
}