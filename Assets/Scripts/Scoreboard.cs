using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Scoreboard : MonoBehaviour
{
	public PlayerScoreBoardItem[] scoreboardItems;
	public PlayerInformation[] playerInformations;

	public void StartUpdate()
	{
		StartCoroutine(ScoreboardRefreshUpdate());
	}
	
	IEnumerator ScoreboardRefreshUpdate()
	{
		WaitForSeconds secs = new WaitForSeconds(0.1f);

		while (!GameManager.Instance.gameIsOver)
		{
			SortTheScoreboard();
			yield return secs;
		}
	}
	
	public void SortTheScoreboard()
	{
		PlayerInformation temp;
		
		for (int i = 0; i < playerInformations.Length; i++)
		{
			for (int j = 0; j < playerInformations.Length - 1; j++)
			{
				if (playerInformations[j].playerScore < playerInformations[j + 1].playerScore)
				{
					temp = playerInformations[j + 1];
					playerInformations[j + 1] = playerInformations[j];
					playerInformations[j] = temp;
				}
			}
		}
		
		for (int i = 0; i < playerInformations.Length; i++)
		{
			playerInformations[i].playerPlacement = i + 1;

		}

		for (int i = 0; i < scoreboardItems.Length; i++)
		{
			scoreboardItems[i].SetPlayerInformation(playerInformations[i]);
		}
	}
	
}
