using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public Transform snowball;
	public PlayerInformation playerInfo;
	
	
	private SnowballGrow snowBallGrow;
	
	// Use this for initialization
	void Start ()
	{
		snowBallGrow = snowball.GetComponent<SnowballGrow>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (snowBallGrow.isDead)
		{
			return;
		}
		
		if (other.transform.CompareTag("Snowball"))
		{	
			iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.ImpactLight);
			
			SnowballGrow otherSnowBalllGrow = other.gameObject.GetComponentInChildren<SnowballGrow>();
			
			if (otherSnowBalllGrow.isDead)
			{
				return;
			}
			
			if (snowBallGrow.size > otherSnowBalllGrow.size )
			{
				otherSnowBalllGrow.Die(transform.name);
				snowBallGrow.Grow(5);
				playerInfo.playerKills++;
				
				if (!playerInfo.isBot)
				{
					GameManager.Instance.gameUI.GetComponent<GameUI>().CreateScorePopUp(5);
				}
			}
		}
		
		if (other.transform.CompareTag("Edible"))
		{
			Edible eat = other.gameObject.GetComponent<Edible>();

			//Debug.Log(snowball.localScale);
			if (eat.edibleThreshold <= snowBallGrow.size)
			{
				eat.GetEaten(transform);
			}
		}
	}

	/*
	void OnCollisionEnter(Collision other)
	{
		if (snowBallGrow.isDead)
		{
			return;
		}

		if (other.transform.CompareTag("Snowball"))
		{	
			SnowballGrow otherSnowBalllGrow = other.gameObject.GetComponentInChildren<SnowballGrow>();
			
			if (otherSnowBalllGrow.isDead)
			{
				return;
			}
			
			if (snowBallGrow.size > otherSnowBalllGrow.size )
			{
				otherSnowBalllGrow.Die(transform.name);
				snowBallGrow.Grow(5);
				playerInfo.playerKills++;
				
				if (!playerInfo.isBot)
				{
					GameManager.Instance.gameUI.GetComponent<GameUI>().CreateScorePopUp(5);
				}
			}
		}
		
		if (other.transform.CompareTag("Edible"))
		{
			Edible eat = other.gameObject.GetComponent<Edible>();

			//Debug.Log(snowball.localScale);
			if (eat.edibleThreshold <= snowBallGrow.size)
			{
				eat.GetEaten(transform);
			}
		}
	}
	*/
}
