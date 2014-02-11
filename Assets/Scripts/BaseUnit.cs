using UnityEngine;
using System.Collections;

public class BaseUnit : MonoBehaviour 
{

	public Projector projector;
	private bool _isSelected;
	//public UnitProperties properties;
	public int id;

	public bool IsSelected
	{
		
		get { return _isSelected; }
		set
		{
			
			if(value)
			{
				
				projector.enabled = true;
				
			}
			else
			{
				
				projector.enabled = false;
				
			}
			
			_isSelected = value;
			
		}
	}
	
	internal virtual void Start ()
	{
			
		UnitController.AddBaseUnitToList(this);
		
	}
	
	public virtual void ActionCallback (Vector3 target) {}
	
}
