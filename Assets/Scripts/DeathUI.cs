using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathUI : MonoBehaviour
{

	public TextMeshProUGUI eaterName;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetEaterName(string _eaterName)
	{
		eaterName.text = _eaterName;
	}
}
