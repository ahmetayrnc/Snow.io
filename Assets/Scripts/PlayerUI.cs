using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
	public TextMeshProUGUI playerName;
	public Transform snowball;

	private Vector3 startScale;
	
	void Start()
	{
		startScale = transform.localScale;
	}
	
	public void SetPlayerName( string _playerName )
	{
		playerName.text = _playerName;
	}

	void Update()
	{
		transform.localScale = startScale + snowball.localScale / 400;
	}
}
