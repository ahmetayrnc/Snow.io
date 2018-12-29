using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnowballMover))]
public class PlayerMovement : MonoBehaviour
{

	public bool doMovement;
	public float speed;
	public VirtualJoystick joystickInput;

	private SnowballMover mover;
	
	// Use this for initialization
	void Start ()
	{
		doMovement = false;
		mover = GetComponent<SnowballMover>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!doMovement)
		{
			mover.rb.velocity = Vector3.zero;
			mover.rb.angularVelocity = Vector3.zero;
			// rb.velocity = Vector3.zero;
			// rb.angularVelocity = Vector3.zero;
			return;
		}

		//Debug.Log("Horizontal: " + joystickInput.Horizontal() + "Vertical: " + joystickInput.Vertical());
		
		float xMovement = joystickInput.Horizontal();
		float zMovement = joystickInput.Vertical();
		//mover.speed = speed;

		mover.UpdateVelocity(xMovement, zMovement);		

		// rb.velocity = xMovement * speed * Vector3.right + zMovement * speed * Vector3.forward + Physics.gravity;

		// rb.angularVelocity = - xMovement * speed * 0.5f * Vector3.forward + zMovement * speed * Vector3.right * 0.5f;
		
		//rb.angularVelocity = rb.velocity;
		
		//transform.Rotate( - zMovement * speed,0, -xMovement * speed);
		
		// if (rb.velocity.x.Equals(0f) && rb.velocity.z.Equals(0f))
		// {
		// 	moving = false;
		// }
		// else
		// {
		// 	moving = true;
		// }
	}
}
