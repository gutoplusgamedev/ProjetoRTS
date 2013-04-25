using UnityEngine;
using System.Collections;
using System;

public class Corotinas : MonoBehaviour {

	public bool CorotinaChamada = false;
	public string impressao;
	public int numero;
	
	void Start () {
	
		StartCoroutine(EsperarEPrintar(impressao, () =>
		{
			
			numero = -100;
			impressao = "O script e' quem controla o valor da impressao! muahahahahha!";
			print (impressao);
			
		} ));
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	IEnumerator EsperarEPrintar (string Print, Action AoQuebrarACorotina)
	{
		
		while(CorotinaChamada)
		{
		
			//WaitForEndOfFrame();
			//WaitForSeconds(float seconds);
			//WaitForFixedUpdate();
			numero = 0;
			yield return StartCoroutine(ContarAte100());
			print (Print);
		
		}
		
		if(AoQuebrarACorotina != null)
			AoQuebrarACorotina();
		
		yield return new WaitForSeconds(1);
		print ("Esperei mais um segundo");
		yield return new WaitForSeconds(2);
		print ("Esperei mais dois segundos");
		yield return new WaitForSeconds(3);
		print ("Esperei mais tres segundos... Pronto, parei!");
		
	}
	
	IEnumerator ContarAte100 ()
	{
		
		while(numero < 100)
		{
			
			numero++;
			yield return new WaitForSeconds(Time.deltaTime);
			
		}
	}
	
	// mover o aldeao ate o ponto de coleta
	// preencher 'mochila' com recursos
	// ir ate o ponto de armazanamento mais proximo...
	
}
