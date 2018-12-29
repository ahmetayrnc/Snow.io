using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SnowballGrow : MonoBehaviour
{
	public bool isDead;
	
	public float size;
	public float growRate;

	private float growRateMultiplier = 0.001f;
	private SnowballMover movement;

	private PlayerInformation playerInfo;
	//private MeshRenderer meshRenderer;
	
	// Use this for initialization
	void Start ()
	{
		//meshRenderer = GetComponent<MeshRenderer>();
		targetScale = transform.localScale;
		movement = GetComponentInParent<SnowballMover>();
		playerInfo = GetComponentInParent<PlayerInformation>();
		
		Physics.IgnoreLayerCollision(9, 9, false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		size = transform.localScale.sqrMagnitude;
		
		if (!movement.moving)
		{
			return;
		}

		if (isDead)
		{
			return;
		}

		transform.localScale += Vector3.one * growRate * growRateMultiplier;
		transform.parent.position += Vector3.up * growRate * growRateMultiplier / 2;

		targetScale = transform.localScale;
	}

	public void Die( string eaterName )
	{
		isDead = true;

		if (!playerInfo.isBot)
		{
			GameManager.Instance.ToggleDeathScreen(eaterName);
		}
		
		SpawnController.Instance.Teleport(transform.parent.parent);

		//Physics.IgnoreLayerCollision(9, 9, true);

		//meshRenderer.enabled = false;
		StartCoroutine(DeathCountdown());
	}

	IEnumerator DeathCountdown()
	{
		yield return new WaitForSeconds(3f);
		
		if (!playerInfo.isBot)
		{
			GameManager.Instance.ToggleDeathScreen("");
		}

		//Physics.IgnoreLayerCollision(9, 9, false);
		
		//meshRenderer.enabled = true;
		isDead = false;
	}
	
	Vector3 targetScale;

	public void Grow( float amount )
	{
		Vector3 growAmount = Vector3.one * growRate * amount / 10;
		targetScale += growAmount;
		float newPosY = transform.position.y + growAmount.y / 2;
		transform.DOScale(targetScale, 0.25f).SetEase(Ease.InSine);
		transform.parent.DOMoveY(newPosY, 0.25f).SetEase(Ease.InSine);

		movement.speed += growAmount.x / 6;
	}
}
