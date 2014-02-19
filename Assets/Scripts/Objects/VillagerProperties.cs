using UnityEngine;
using System.Collections;

public class VillagerProperties : MobileUnitProperties 
{
	public ResourceType currentResource;
	public int currentResourceAmount;
	public int resourceCapacity;
	public int unitsGatheredPerSecond;

	public bool IsFull
	{
		get { return currentResourceAmount >= resourceCapacity; }
	}

	public void GiveResources (IResourceReceiver receiver)
	{
		receiver.ReceiveResource (currentResourceAmount, currentResource);
		currentResourceAmount = 0;
	}
}
