using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PlayerInformation : MonoBehaviour
{	
	public string playerName;

	public int playerScore;
	public int playerPlacement;
	public int playerStars;
	public int playerKills;
	
	public PlayerUI playerUI;
	public PlayerMovement playerMovement;

	public bool isBot;
	
	// Use this for initialization
	void Start ()
	{	
		playerUI = GetComponentInChildren<PlayerUI>();
		playerMovement = GetComponentInChildren<PlayerMovement>();

		playerPlacement = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SetPlayerName(string _playerName)
	{
		playerName = _playerName;
		playerUI.SetPlayerName(playerName);
		
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).name = playerName;
		}

		transform.name = playerName;
	}

	public void AddScore(int amount)
	{
		playerScore += amount;
	}
}
