using UnityEngine;
using System.Collections.Generic;

public class EntitiesHolder : MonoBehaviour 
{
	private static MobileEntityProperties[] _mobileProps;
	private static StaticEntityProperties[] _staticProps;
	private const string _mobileXmlPath = "XMLFiles/CharactersInfo";
	private const string _staticXmlPath = "XMlFiles/BuildingsInfo";

	void Start ()
	{
		TextAsset charactersInfo = Resources.Load<TextAsset> (_mobileXmlPath);
		_mobileProps = XMLParser.ParseCharacters (charactersInfo.text);
		TextAsset buildingsInfo = Resources.Load<TextAsset> (_staticXmlPath);
		_staticProps = XMLParser.ParseBuildings (buildingsInfo.text);
	}

	public static EntityProperties[] LoadEntitiesAvailableOnId (int id)
	{
		List<EntityProperties> returnList = new List<EntityProperties> ();

		foreach (MobileEntityProperties m in _mobileProps)
		{
			if(m.AvailableOn == id)
			{
				returnList.Add(m);
			}
		}

		foreach (StaticEntityProperties s in _staticProps)
		{
			if(s.AvailableOn == id)
			{
				returnList.Add(s);
			}
		}

		return returnList.ToArray ();
	}
}
