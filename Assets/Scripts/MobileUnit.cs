using UnityEngine;
using System.Collections;

public class MobileUnit: BaseUnit {

	// Use this for initialization
	internal override void Start () {
	
		base.Start();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator MoveTo (Vector3[] path)
	{
		
		for(int i = 0; i < path.Length; i++)
		{
			
			Vector3 direction = Vector3.zero;
			
			do
			{
				
				direction = (path[i] - transform.position);
				MovementCallback(direction.normalized);
				yield return null;
				
				
			} while (direction.sqrMagnitude > 0.1f);
		}
	}
	
	public void MovementCallback (Vector3 direction)
	{
		
		transform.position += direction * Time.deltaTime;
		
	}	
	
	public override void ActionCallback (Vector3 target)
	{
		
		StartCoroutine(MoveTo(new Vector3[1] { target }));
	
	}
}
