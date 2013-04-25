using UnityEngine;
using System.Collections;

public class Campones : MonoBehaviour {
	
	public string nome;
	public bool receberOrdem;
	
	void Start ()
	{
		
		if(receberOrdem)
			Delegates.AoReceberOrdemDoRei += AoReceberOrdemDoRei;
		
	}
	
	void OnDisable ()
	{
		
		Delegates.AoReceberOrdemDoRei -= AoReceberOrdemDoRei;
		
	}
	
	void AoReceberOrdemDoRei (string ordem)
	{
		
		print ("Meu nome e' " + nome + " e o rei mandou: " + ordem);
		
	}
}
