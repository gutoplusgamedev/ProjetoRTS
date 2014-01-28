using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour {

	public MobileEntityProperties[] entities;
	public TextAsset xml;

	void Start ()
	{
		entities = XMLParser.ParseCharacters (xml.text);
	}
}
