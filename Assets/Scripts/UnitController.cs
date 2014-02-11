using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitController : MonoBehaviour {
	
	private Vector2 _initialPosition;
	private Vector2 _finalPosition;
	public Texture2D RectangleTexture;
	private static List<BaseUnit> _unitsInScene;
	public Camera mainCamera;
	private BaseUnit[] _selectedUnits;
	
	void Awake ()
	{
		
		_unitsInScene = new List<BaseUnit>();
		_selectedUnits = new BaseUnit[0];
		
	}
	
	void Update ()
	{
		
		if(Input.GetButtonUp("Fire2"))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray.origin, ray.direction, out hit))
			{
				
				foreach(BaseUnit unit in _selectedUnits)
				{
					
					unit.ActionCallback(hit.point);
					
				}
			}
		}
	}
	
	void OnGUI ()
	{
		
		if(Input.GetButtonDown("Fire1"))
		{
			
			_initialPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
			
		}
		
		if(Input.GetButton("Fire1"))
		{
			
			_finalPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
			GUI.DrawTexture(new Rect(_initialPosition.x, _initialPosition.y, _finalPosition.x - _initialPosition.x, _finalPosition.y - _initialPosition.y), RectangleTexture);
			
		}
		
		if(Input.GetButtonUp("Fire1"))
		{
			if(_finalPosition == _initialPosition)
			{
				return;
			}

			foreach(BaseUnit unit in _selectedUnits)
			{
				
				unit.IsSelected = false;
				
			}
			
			float xMin = Mathf.Min(_initialPosition.x, _finalPosition.x);
			float yMin = Mathf.Min(_initialPosition.y, _finalPosition.y);
			float width = Mathf.Abs(_initialPosition.x - _finalPosition.x);
			float height = Mathf.Abs(_initialPosition.y - _finalPosition.y);
			
			_selectedUnits = GetUnitsUnderRectangle(new Rect(xMin, yMin, width, height));
			
			foreach(BaseUnit unit in _selectedUnits)
			{
				
				unit.IsSelected = true;
				
			}
		}
	}

	private BaseUnit[] GetUnitsUnderRectangle (Rect selectionRectangle)
	{
		
		List<BaseUnit> selectedUnits = new List<BaseUnit>();
		
		foreach(BaseUnit unit in _unitsInScene)
		{
			
			Vector3 unitPositionInScene = mainCamera.WorldToScreenPoint(unit.transform.position);
			Vector2 convertedUnitPosition = new Vector2(unitPositionInScene.x, Screen.height - unitPositionInScene.y);
			if(selectionRectangle.Contains(convertedUnitPosition))
			{
				
				selectedUnits.Add(unit);
				
			}
		}
		
		return selectedUnits.ToArray();
		
	}
		
	public static void AddBaseUnitToList (BaseUnit unit)
	{
		
		_unitsInScene.Add(unit);
		
	}
}
