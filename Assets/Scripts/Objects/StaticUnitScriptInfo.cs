using UnityEngine;
using System.Collections;

public class StaticUnitScriptInfo 
{
	public string script;
	public string[] arguments;

	public StaticUnitScriptInfo (string script, string[] arguments)
	{
		this.script = script;
		this.arguments = arguments;
	}
}
