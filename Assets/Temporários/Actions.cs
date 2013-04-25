using UnityEngine;
using System.Collections;
using System;

public class Actions : MonoBehaviour {
	
	private string currentKey;
	
	IEnumerator CountDown (int contagem, Action aoCompletar)
	{
		
		yield return new WaitForSeconds(contagem);
		if(aoCompletar != null)
			aoCompletar();
		
	}
	
}
