using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Vector3 offSet;
	public Transform target;
	public Transform snowball;
	
	// Use this for initialization
	void Start ()
	{
		//offSet = transform.position - target.position;
		//rends = new List<Renderer>();// 	
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		Vector3 newOffset = offSet;
		newOffset.y += 2 * snowball.localScale.y;
		newOffset.z -= 2 * snowball.localScale.z;
		transform.position = Vector3.Lerp(transform.position, target.position + newOffset, 0.8f);
	}
	
	private Vector3 dir;
	public GameObject player;

	//public Material transparent;
	//public Material defaultMat;
	
	//private List<Renderer> rends;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		dir = player.transform.position - Camera.main.transform.position;

		LayerMask viewMask;
		viewMask = LayerMask.GetMask("Edible");		
		
		RaycastHit[] hits;
		hits = Physics.RaycastAll(player.transform.position, -dir, 1000, viewMask);

		for (int i = 0; i < hits.Length; i++)
		{
			RaycastHit hit = hits[i];
			Renderer rend = hit.transform.GetComponent<Renderer>();

			if (rend)
			{
				//rends.Add(rend);
				hit.collider.GetComponent<Edible>().RayHit();
				//Color tempColor = rend.material.color;
				//tempColor.a = 0.3f;
				//rend.material.color = tempColor;
				//Debug.Log(hit.transform.name);
			}
		}
	}

	//public IEnumerator OnPostRender()
	//{
	//	yield return new WaitForEndOfFrame();
	//	
	//	Debug.Log("OnPostRender");
	//	for (int i = 0; i < rends.Count; i++)
	//	{
	//		rends[i].material = defaultMat;
	//		Debug.Log(rends[i].transform.name);
	//	}
	//	rends.Clear();
	//}
}
