using UnityEngine;
using System.Collections;

public class BuildingPlacer : MonoBehaviour 
{
	private static GameObject _building = null;
	private static int _buildingId;

	public static bool IsPlacing 
	{
		get { return _building != null; }
	}

	public static void Create (int id)
	{
		_buildingId = id;
		DestroyCurrent ();
		InstantiateNewBuilding (string.Empty); // incompleto
	}

	public static void DestroyCurrent ()
	{
		if (_building != null) 
		{
			Destroy(_building);
			_building = null;
		}
	}

	private static void InstantiateNewBuilding (string path)
	{
		// buscar a construção disponivel no caminho passado como parametro
		_building = GameObject.CreatePrimitive (PrimitiveType.Cube); // incompleto
		_building.GetComponent<BoxCollider> ().enabled = false;
	}

	private static void PlaceBuilding ()
	{
		GameObject newBuilding = GameObject.CreatePrimitive (PrimitiveType.Cube);
		newBuilding.transform.position = _building.transform.position;
		StaticEntityProperties properties = EntitiesHolder.LoadEntityById (_buildingId) as StaticEntityProperties;
		newBuilding.AddComponent(System.Type.GetType(properties.scriptInfo.script)); // alterado devido a atualização Unity 5.x
		(newBuilding.GetComponent (properties.scriptInfo.script) as BaseUnit).OnCreated (properties.scriptInfo.arguments);
		DestroyCurrent ();
	}

	void Update () 
	{
		if (IsPlacing) 
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(r.origin, r.direction, out hit))
			{
				_building.transform.position = hit.point;
			}

			if(Input.GetKeyUp(KeyCode.Escape))
			{
				DestroyCurrent();
			}

			if(Input.GetButtonDown("Fire1"))
			{
				PlaceBuilding();
			}
		}
	}
}
