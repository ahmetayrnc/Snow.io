using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreBoardItem : MonoBehaviour
{
	public PlayerInformation playerInfo;
	public TextMeshProUGUI playerPlacement;
	public TextMeshProUGUI playerScore;
	public TextMeshProUGUI playerName;
	
	
	// Update is called once per frame
	void Update ()
	{	
		playerPlacement.text = playerInfo.playerPlacement +  " -";
		playerScore.text = playerInfo.playerScore + "pt";
		playerName.text = playerInfo.playerName + "";
		//playerInfoText.text = playerInfo.playerPlacement + " - " + playerInfo.playerScore + "pt " + playerInfo.playerName;
	}

	public void SetPlayerInformation( PlayerInformation _playerInfo )
	{
		playerInfo = _playerInfo;
	}
}
