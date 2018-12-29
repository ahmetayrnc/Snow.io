using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	
	[SerializeField]
	private int scene;

	public GameObject menuUI;
	public GameObject loadingUI;
	
	public void LoadScene()
	{
		Debug.Log("FUCKING HELL");
		menuUI.SetActive(false);
		loadingUI.SetActive(true);
		SceneManager.LoadScene(scene);
	}
}