using UnityEngine;

public enum ResourceType
{
	
	Gold,
	Wood,
	Food
	
}

public class ResourceRoot : MonoBehaviour {

	public ResourceType resource;
	[SerializeField]
	private int resourcesLeft;
	public delegate void EmptySourceEventHandler ();
	public event EmptySourceEventHandler OnEmptySource;
	
	public int GatherFromHere (int desiredAmount)
	{
		
		if(desiredAmount <= resourcesLeft)
		{
			
			resourcesLeft -= desiredAmount;
			return desiredAmount;
			
		}
		else
		{
			
			resourcesLeft = 0;
			
			if(OnEmptySource != null)
				OnEmptySource();
			
			return resourcesLeft;
			
		}
	}
}
