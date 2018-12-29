using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

	public static SpawnController Instance;
	
	public Transform[] players;
	
	public Transform spawnPointsParent;
	public Transform[] spawnPoints;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		spawnPoints = new Transform[spawnPointsParent.childCount];

		for (int i = 0; i < spawnPoints.Length; i++)
		{
			spawnPoints[i] = spawnPointsParent.GetChild(i);
		}

		int n = spawnPoints.Length;
		while (n > 1) 
		{
			int k = Random.Range(0,n--);
			var temp = spawnPoints[n];
			spawnPoints[n] = spawnPoints[k];
			spawnPoints[k] = temp;
		}
		
		for (int i = 0; i < players.Length; i++)
		{
			players[i].position = spawnPoints[i].position;
		}
	}

	public void Teleport( Transform deadPlayer )
	{
		int randomIndex = Random.Range(0, spawnPoints.Length);

		Vector3 newPos = spawnPoints[randomIndex].position;
		newPos.y = deadPlayer.GetChild(1).position.y;
		deadPlayer.GetChild(1).position = newPos;
	}
}
