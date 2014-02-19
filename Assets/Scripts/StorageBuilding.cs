using UnityEngine;
using System.Collections.Generic;

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

	public override void OnCreated (string[] arguments)
	{
		_acceptedResources = new ResourceType[arguments.Length];
		for (int i = 0; i < _acceptedResources.Length; i++)
		{
			_acceptedResources[i] = (ResourceType)System.Enum.Parse (typeof(ResourceType), arguments[i]);
		}
	}
}
