using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
	public TMP_InputField nameInput;
	public TextMeshProUGUI best;

	void Start()
	{
		nameInput.text = PlayerPrefs.GetString("playerName", "Player");

		if (!PlayerPrefs.HasKey("best"))
		{
			PlayerPrefs.SetInt("best", 0);
		}
		
		best.text = "Best " + PlayerPrefs.GetInt("best");
	}
	
	void Update()
	{
		
	}
	
	public void StartGame()
	{
		MenuManager.Instance.StartGame();
	}

	public void SetName( string _playername )
	{
		PlayerStats.playerName = _playername;
		PlayerPrefs.SetString("playerName", _playername);
	}
}
