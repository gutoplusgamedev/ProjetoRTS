using UnityEngine;
using System.Collections;

public class Delegates : MonoBehaviour {

	public delegate void ChamadoDoRei (string ordem);
	public static event ChamadoDoRei AoReceberOrdemDoRei;
	
	void Update ()
	{
		
		if(Input.GetKeyUp(KeyCode.Return))
		{
			
			if(AoReceberOrdemDoRei != null)
			{
				
				AoReceberOrdemDoRei("Vao carpir um lote!");
				
			}
		}
	}
}
