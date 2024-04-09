using UnityEngine;

/// <summary>
/// Manages which type of player control rig gets instantiated to the attached <see cref="GameObject"/>. 
/// Only one instance of this script should exist in a given scene!
/// </summary>
public class PlayerControlMethodSelector : MonoBehaviour
{
	private enum PlayerControlMethod
	{
		VirtualReality,
		FirstPerson,
	}

	[SerializeField]
	private PlayerControlMethod controlMethod;

	[SerializeField]
	private GameObject virtualRealityPlayerRig;

	[SerializeField]
	private GameObject firstPersonPlayerRig;


    void Start()
    {
		ApplySelectedPlayerControlMethod();
    }

	private void ApplySelectedPlayerControlMethod()
	{
		switch (controlMethod)
		{
			case PlayerControlMethod.VirtualReality:
				TryToInstantiatePlayerRig(virtualRealityPlayerRig);
				break;

			case PlayerControlMethod.FirstPerson:
				TryToInstantiatePlayerRig(firstPersonPlayerRig);
				break;
		}
	}

	private void TryToInstantiatePlayerRig(GameObject playerRig)
	{
		bool isRigAssigned = playerRig != null;
		if (isRigAssigned)
		{
			Instantiate(playerRig, this.transform);
		}
		else
		{
			ThrowRigNotAssignedError(this.virtualRealityPlayerRig.name);
		}
	}

	private void ThrowRigNotAssignedError(string rigName)
	{
		throw new UnassignedReferenceException("Can not instantiate " + rigName + ". Has a prefab been assigned for it in the inspector?");
	}
}