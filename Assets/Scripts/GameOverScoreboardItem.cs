using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScoreboardItem : MonoBehaviour
{
	public PlayerInformation playerInfo;
	public TextMeshProUGUI playerPlacementText;
	public TextMeshProUGUI playerScore;
	public TextMeshProUGUI playerName;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerPlacementText.text = playerInfo.playerPlacement + "";
		playerScore.text = playerInfo.playerScore + "pts";
		playerName.text = playerInfo.playerName + "";
		//playerInfoText.text = playerInfo.playerPlacement + " - " + playerInfo.playerScore + "pts " + playerInfo.playerName + " " + playerInfo.playerStars;
	}
}
