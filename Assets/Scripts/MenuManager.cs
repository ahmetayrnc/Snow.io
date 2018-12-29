using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public static MenuManager Instance;
	
	public string MainSceneName = "Main";

	public float gameDuration = 120f;
	public float countdown;
	
	void Awake()
	{
		Instance = this;
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		SceneManager.LoadScene(MainSceneName);
	}
}
