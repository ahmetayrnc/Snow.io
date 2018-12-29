using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPopUps : MonoBehaviour
{

	public Transform seconds60;
	public Transform seconds30;
	public Transform seconds10;

	public TextMeshProUGUI seconds10Text;
	
	public bool timerShowing;

	private GameManager gameManager;
	
	// Use this for initialization
	void Start () 
	{
		gameManager = GameManager.Instance;
		timerShowing = false;
		
		seconds10.gameObject.SetActive(false);	
		seconds30.gameObject.SetActive(false);	
		seconds60.gameObject.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (timerShowing)
		{
			return;
		}
		
		if (gameManager.countdown < 61f && gameManager.countdown > 60f)
		{
			StartCoroutine(Show60Seconds());
			return;
		}
		
		if (gameManager.countdown < 31f && gameManager.countdown > 30f)
		{
			StartCoroutine(Show30Seconds());
			return;
		}
		
		if (gameManager.countdown < 11f && gameManager.countdown > 10f)
		{
			StartCoroutine(Show10Seconds());
		}
	}

	IEnumerator Show60Seconds()
	{
		timerShowing = true;
		
		seconds60.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		seconds60.gameObject.SetActive(false);

		timerShowing = false;
	}

	IEnumerator Show30Seconds()
	{
		timerShowing = true;
		
		seconds30.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		seconds30.gameObject.SetActive(false);
		
		timerShowing = false;
	}

	IEnumerator Show10Seconds()
	{
		timerShowing = true;
		
		seconds10.gameObject.SetActive(true);
		
		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds(1);
			seconds10Text.text = 9 - i + "s";
		}
		
		seconds10.gameObject.SetActive(false);
	}
}
