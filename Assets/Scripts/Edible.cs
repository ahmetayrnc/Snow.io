using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class Edible : MonoBehaviour
{
	public float edibleThreshold;

	public bool boundary;
	
	private MeshRenderer meshRenderer;
	
	public Vector3 size;

	
	void Start()
	{
		if (boundary)
		{
			edibleThreshold = 1000000000000;
		}
		else
		{
			meshRenderer = GetComponent<MeshRenderer>();
		
			size.x = meshRenderer.bounds.size.x;
			size.y = meshRenderer.bounds.size.y;
			size.z = meshRenderer.bounds.size.z;
			
			edibleThreshold = size.sqrMagnitude;
		}
	}

	private void Update()
	{
		if (boundary)
		{
			return;
		}
		
		opaqueCountdown += Time.deltaTime;

		if (opaqueCountdown > 0.1f)
		{
			meshRenderer.material = GameManager.Instance.defaultMat;
		}
	}

	public void GetEaten(Transform player)
	{	
		transform.SetParent(player);
		transform.gameObject.layer = LayerMask.GetMask("Default");
		transform.GetComponent<Collider>().enabled = false;

		SnowballGrow grow = player.GetComponentInChildren<SnowballGrow>();

		var snowball = player.GetChild(0); 
		
		//Debug.Log("pos" + transform.position + "locpos" + transform.localPosition + "center" + transform.gameObject.GetComponent<Renderer>().bounds.center);

		//Vector3 center =  transform.position - transform.gameObject.GetComponent<Renderer>().bounds.center;
		
		//Debug.Log(center);
		
		//Vector3 pos = Vector3.zero;

		Vector3 pos;
		
		//Debug.Log(transform.name + "localscale-pos: " + pos);
		
		//Vector3 offset = (1 - (edibleThreshold / grow.size)) * snowball.GetChild(0).localScale * 0.5f;

		//Debug.Log((1 - (edibleThreshold / grow.size)));
		
		//Debug.Log(transform.name + "offset: " + offset);

		//var scale = (snowball.localScale * 0.5f).x;
		//var ratio = edibleThreshold / grow.size;
		//var offset = Vector3.Lerp(snowball.localPosition + (new Vector3(Random.value, Random.value, Random.value)).normalized * scale, snowball.localPosition, ratio);
		
		//pos = offset;

		// new
		Vector3 dir = (transform.localPosition - Vector3.zero).normalized;

		Vector3 movementAmount = dir * (size.x / 2);// + (size.y / 2) + (size.z / 2)) / 3;

		Vector3 pos2 = transform.localPosition - movementAmount;

		transform.DOLocalMove(pos2, 1f);
		//end new
		
		//Debug.Log(transform.name + "pos: " + pos);
		
		//transform.DOLocalMove(pos, 1f);

		int growAmount = 0;

		if (edibleThreshold <= 20f)
		{
			growAmount = 1;
		}
		else if (edibleThreshold <= 40f)
		{
			growAmount = 1;
		}
		else if (edibleThreshold <= 80f)
		{
			growAmount = 2;
		}
		else if (edibleThreshold <= 160f)
		{
			growAmount = 3;
		}
		else if (edibleThreshold <= 320f)
		{
			growAmount = 4;
		}
		else if (edibleThreshold <= 640f)
		{
			growAmount = 5;
		}
		else if (edibleThreshold <= 1280f)
		{
			growAmount = 6;
		}
		else if (edibleThreshold <= 1600f)
		{
			growAmount = 7;
		}
		else if (edibleThreshold <= 2000f)
		{
			growAmount = 8;
		}
		else if (edibleThreshold <= 2400)
		{
			growAmount = 9;
		}
		else
		{
			growAmount = 10;
		}
		
		grow.Grow(growAmount);

		PlayerInformation playerInfo = player.GetComponentInParent<PlayerInformation>();

		player.GetComponentInParent<PlayerInformation>().AddScore(growAmount);
		
		if (!playerInfo.isBot)
		{
			GameManager.Instance.gameUI.GetComponent<GameUI>().CreateScorePopUp(growAmount);
		}
	}

	private float opaqueCountdown = 0f;
	public void RayHit()
	{
		opaqueCountdown = 0.0f;
		
		meshRenderer.material = GameManager.Instance.transparentMat;
	}
}
