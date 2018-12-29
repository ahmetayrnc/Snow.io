using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NameManager : MonoBehaviour
{

	public List<string> namelist;
	
	public PlayerInformation[] playerInformations;
	
	// Use this for initialization
	void Start ()
	{
		namelist = GameManager.Instance.nameArray.ToList();

		StartCoroutine(NameBots());
	}

	IEnumerator NameBots()
	{
		yield return new WaitForSeconds(1f);
		for (int i = 0; i < playerInformations.Length; i++)
		{
			int randomIndex = Random.Range(0, namelist.Count - 1);
			string playerName = namelist[randomIndex];
			playerInformations[i].SetPlayerName(playerName);
			namelist.RemoveAt(randomIndex);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
