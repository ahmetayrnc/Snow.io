using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameFollow : MonoBehaviour
{

	public Vector3 offSet;
	public Transform target;
	public Transform snowball;
	
	// Use this for initialization
	void Start ()
	{
		offSet = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 newOffset;
		newOffset.x = target.position.x;
		newOffset.y = snowball.localScale.y / 2f + target.position.y + 1;
		newOffset.z = snowball.localScale.z / 4f + target.position.z + 1;
		transform.position = newOffset;
	}
}
