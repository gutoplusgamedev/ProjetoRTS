using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float minDistanceToBorder;
	public float movementVelocity;
	
	void Update ()
	{
		
		float scrHeight = Screen.height;
		float scrWidth = Screen.width;
		Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		
		float yBorder = scrHeight - mouse.y;
		float xBorder = scrWidth - mouse.x;
		
		Vector3 movement = Vector3.zero;
		
		if(yBorder < minDistanceToBorder)
		{
			
			movement = new Vector3(movement.x, movement.y, minDistanceToBorder - yBorder);
			
		} 
		else if (mouse.y < minDistanceToBorder)
		{
			
			movement = new Vector3(movement.x, movement.y, -(minDistanceToBorder - mouse.y));
			
		}
		
		if(xBorder < minDistanceToBorder)
		{
			
			movement = new Vector3(minDistanceToBorder - xBorder, movement.y, movement.z);
			
		}
		else if (mouse.x < minDistanceToBorder)
		{
			
			movement = new Vector3(-(minDistanceToBorder - mouse.x), movement.y, movement.z);
			
		}
		
		float forward = Input.GetAxis("Forward") * minDistanceToBorder * movementVelocity;
		float right = Input.GetAxis("Right") * minDistanceToBorder * movementVelocity;
		
		movement = new Vector3(movement.x + right, movement.y, movement.z + forward);
		
		transform.Translate(movement * Time.deltaTime * movementVelocity, Space.World);
		
	}
}
