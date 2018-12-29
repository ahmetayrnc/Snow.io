using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public string[] nameArray;
	
	public GameObject realPlayer;
	public PlayerInformation playerInformation;

	public GameObject deathUI;
	public GameObject controlUI;
	public GameObject gameUI;
	public GameObject gameOverUI;
	public GameObject countdownTexts;
	public PlayerMovement playerMovement;

	public SnowballMover[] snowballMovers;
	
	public Material defaultMat;
	public Material transparentMat;
	
	public string MainSceneName = "Main";

	public float gameDuration = 120f;
	public float countdown;

	public bool gameIsOver = true;

	public Scoreboard scoreboard;
	public GameOverScoreboard endScoreboard;
	
	void Awake()
	{
		Instance = this;

		Application.targetFrameRate = 60;
	}
	
	// Use this for initialization
	void Start ()
	{	
		playerInformation = realPlayer.GetComponent<PlayerInformation>();
		
		// Starts the game
		StartGame();

		nameArray = new string[]
		{
			"Lolumut","Izzy23","Chilly Pubble","CHEEKY MONKEY","VIKING","PITBULL","MERLIN","FLASH","anowhu","eshes","ceactave",
			"zofisenout","tetinsald","tenowiet","illai","lathe","orate","sansuttir","ratear","rirsulico","suesciess","daterarse",
			"zurithin","tousatic","h3ym4n","c00lbr0s","aqw6","omgtownismine","brad","samvan","someone","everyBodyInMyA33",
			"kisesed","Rosalee","Foster","Rosemarie","Rosie","Hayley","Smith","Kira","Ashley","Barrett","Brown","Rayne",
			"DiamandaJackson","Olympe12","Eglantine_poq","Shadow_rise","_chancellor","Sadie","Jennie","Mandi","Rosie",
			"Amy Potter","I’LL FIND YOU","COME AND FIND ME","EAT ME","DON’T EAT ME", "Snower", "Shodaw_Destroyer99", "CAN YOU EAT ME?",
			"HEY_MAN", "hi_there", "filozofHasan", "Sen Kimsin Ya!!", "EYYY!", "Binary_IH_IH_IH"
		};

		GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "game");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// countdown stuff for the game time
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0, Mathf.Infinity);

		if (countdown <= 0f)
		{
			EndGame();
		}
	}

	public void StartGame()
	{
		// game is not over
		gameIsOver = false;
		
		// sets up the game time
		countdown = gameDuration + 3f;
		
		// sets up the uis
		controlUI.SetActive(true);
		gameOverUI.SetActive(false);
		gameUI.SetActive(false);

		// closes real player movement
		for (int i = 0; i < snowballMovers.Length; i++)
		{
			snowballMovers[i].doMovement = false;
		}
		
		playerMovement.doMovement = false;
		
		// sets up the real players name
		playerInformation.SetPlayerName(PlayerStats.playerName);
		
		// starts the start countdown
		StartCoroutine(StartCountdown());
	}

	IEnumerator StartCountdown()
	{
		countdownTexts.SetActive(true);
		
		yield return new WaitForSeconds(3f);
		
		countdownTexts.SetActive(false);
		
		gameUI.SetActive(true);
		
		// closes real player movement
		for (int i = 0; i < snowballMovers.Length; i++)
		{
			snowballMovers[i].doMovement = true;
		}
		
		playerMovement.doMovement = true;
		
		scoreboard.StartUpdate();
	}
	
	public void EndGame()
	{
		gameIsOver = true;
		
		endScoreboard.SortTheScoreboard();
		
		controlUI.SetActive(false);
		gameUI.SetActive(false);
		gameOverUI.SetActive(true);
		
		// closes real player movement
		for (int i = 0; i < snowballMovers.Length; i++)
		{
			snowballMovers[i].doMovement = false;
		}
		
		playerMovement.doMovement = false;

		if (playerInformation.playerScore > PlayerPrefs.GetInt("best"))
		{
			PlayerPrefs.SetInt("best", playerInformation.playerScore);
			PlayerPrefs.Save();
		}
		
		GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "game", playerInformation.playerScore);
		GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "placement", playerInformation.playerPlacement);
		GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "killCount", playerInformation.playerKills);
		GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "playerName", playerInformation.playerName);
	}

	public void ToggleDeathScreen(string eaterName)
	{
		if (deathUI.activeSelf)
		{
			deathUI.SetActive(false);
		}
		else
		{
			deathUI.GetComponent<DeathUI>().SetEaterName(eaterName);
			deathUI.SetActive(true);
		}
	}
}
