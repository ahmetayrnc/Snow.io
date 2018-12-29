using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraViewController : MonoBehaviour
{
	private Vector3 dir;
	public GameObject player;

	public Material transparent;
	public Material defaultMat;
	
	private List<Renderer> rends;
	
	// Use this for initialization
	void Start () 
	{
		rends = new List<Renderer>();
		//StartCoroutine(RenderUpdateKinda());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		dir = player.transform.position - Camera.main.transform.position;

		LayerMask viewMask;
		viewMask = LayerMask.GetMask("Edible");		
		
		RaycastHit[] hits;
		hits = Physics.RaycastAll(Camera.main.transform.position, dir, 1000, viewMask);

		for (int i = 0; i < hits.Length; i++)
		{
			RaycastHit hit = hits[i];
			Renderer rend = hit.transform.GetComponent<Renderer>();

			if (rend)
			{
				rends.Add(rend);
				
				rend.material = transparent;
				//Color tempColor = rend.material.color;
				//tempColor.a = 0.3f;
				//rend.material.color = tempColor;
				//Debug.Log(hit.transform.name);
			}
		}
	}

	IEnumerator RenderUpdateKinda()
	{
		var frameEnd = new WaitForEndOfFrame();
		while (true)
		{
			
			Debug.Log("OnPostRenderCor");
			for (int i = 0; i < rends.Count; i++)
			{
				rends[i].material = defaultMat;
				Debug.Log(rends[i].transform.name);
			}
			rends.Clear();
			yield return frameEnd;
		}
	}
	
	public void OnPostRender()
	{
		Debug.Log("OnPostRender");
		for (int i = 0; i < rends.Count; i++)
		{
			rends[i].material = defaultMat;
			Debug.Log(rends[i].transform.name);
		}
		rends.Clear();
	}
}
