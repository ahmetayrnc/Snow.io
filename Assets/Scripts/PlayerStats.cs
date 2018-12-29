using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static string playerName;
	public static int best;

	void Start()
	{
		best = PlayerPrefs.GetInt("best", 0);
		playerName = PlayerPrefs.GetString("playerName", "Player");
	}
}
