using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

	public string mainMenuSceneName = "MainMenu";

	public void MainMenu()
	{
		SceneManager.LoadScene(mainMenuSceneName);
	}
}
