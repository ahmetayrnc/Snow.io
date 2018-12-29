using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour {

	public TextMeshProUGUI countdownText;
	public TextMeshProUGUI killsText;
	public Transform scorePopUpParent;
	public TextMeshProUGUI scorePopUpPrefab;

	public PlayerInformation playerInformation;
	
	// Use this for initialization
	void Start ()
	{
		playerInformation = GameManager.Instance.playerInformation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		countdownText.text = string.Format("{0:D2}:{1:D2}", (int)(GameManager.Instance.countdown / 60),
			(int)(GameManager.Instance.countdown % 60));

		if (playerInformation == null)
		{
			playerInformation = GameManager.Instance.playerInformation;
			return;
		}
		
		killsText.text = "Kills: " + playerInformation.playerKills;
	}

	public void CreateScorePopUp(int amount)
	{
		TextMeshProUGUI text = Instantiate(scorePopUpPrefab, scorePopUpParent);
		text.text = "+" + amount;
		
		Destroy(text.gameObject, 2f);
	}
}
