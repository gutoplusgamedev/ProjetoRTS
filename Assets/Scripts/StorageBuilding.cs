using UnityEngine;
using System.Collections;

public class StorageBuilding : StaticUnit, IResourceReceiver 
{
	[SerializeField]
	private ResourceType[] _acceptedResources;

	public ResourceType[] AcceptedResources
	{
		get { return _acceptedResources; }
	}

	public void ReceiveResource (int amount, ResourceType resource)
	{
		// Envie os recursos para a town center
	}

	public bool AcceptResource (ResourceType type)
	{
		foreach (ResourceType acceptedResource in _acceptedResources)
		{
			if(acceptedResource == type)
			{
				return true;
			}
		}

		return false;
	}
}
