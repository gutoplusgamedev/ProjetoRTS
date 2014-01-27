using UnityEngine;
using System.Collections;

[System.Serializable]
public class ResourceSet
{
	public int wood, food, gold;

	public ResourceSet (int wood, int food, int gold)
	{
		this.wood = wood;
		this.food = food;
		this.gold = gold;	
	}
}
