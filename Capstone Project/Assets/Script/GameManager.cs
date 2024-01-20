using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ManagerInstance;

    [SerializeField] private PlayerStats playerStats;

    public GameObject playerGO;
    public PlayerMovement player;
    public PlayerProperties playerProperties;
    
    public Slider playerHP;
    public Slider playerEXP;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI timerDisplay;
    public TextMeshProUGUI enemyKilled;
    public TextMeshProUGUI timeSurvived;
    public TextMeshProUGUI totalScore;
    public TextMeshProUGUI gainedDNA;

    public GameObject autoShoot;
    public GameObject levelUpScreen;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    public enum GameState { MainMenu, SelectLevel, InGame };

    public GameState state;
    
    private bool pause = false;
    private float score = 0;
    private float elapsedTime = 0;
    private float kill = 0;
    private float dna = 0;
    private void Awake()
    {
        if (ManagerInstance == null)
        {
            ManagerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) state = GameState.MainMenu;
        if (SceneManager.GetActiveScene().buildIndex == 1) state = GameState.SelectLevel;
        if (SceneManager.GetActiveScene().buildIndex == 2) state = GameState.InGame;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(state == GameState.InGame && player != null)
        {
            if (player.AutoShoot()) autoShoot.SetActive(true);
            else autoShoot.SetActive(false);
            Timer();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && state == GameState.InGame && player != null)
        {
            PauseScreen();
        }
        
        elapsedTime += Time.deltaTime;

    }

    public void Retry()
    {  
        if(player != null)
        {
            player = playerGO.GetComponent<PlayerMovement>();
            playerProperties = playerGO.GetComponent<PlayerProperties>();
        }
        elapsedTime = 0f;
        Time.timeScale = 1f;
    }

    public void UpdateEXP(float EXP)
    {
        playerEXP.value = EXP;
        playerHP.GetComponentInChildren<TextMeshProUGUI>().text = EXP.ToString();

        playerLevel.text = "Lv " + playerProperties.Level().ToString();
    }
    public void LevelUpChosen()
    {
        levelUpScreen.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject chosen = EventSystem.current.currentSelectedGameObject;

        playerProperties.StatsUpgrade("attack", 1f);

        levelUpScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void ResetElapsedTime()
    {
        elapsedTime = 0f;
    }
    public float ElapsedTime()
    {
        return elapsedTime;
    }

    public void PauseScreen()
    {
        if(!pause)
        {
            pause = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pause = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void DeathScreen()
    {
        deathScreen.SetActive(true);
        DisplayScore();
        Time.timeScale = 0f;
    }

    private void DisplayScore()
    {
        totalScore.text = ((int)score).ToString();

        timeSurvived.text = string.Format("{0:00}:{1:00}", (int)(elapsedTime / 60), (int)(elapsedTime % 60));

        enemyKilled.text = ((int)kill).ToString();

        gainedDNA.text = ((int)dna).ToString();

        playerStats.DNA = (int)dna;
    }
    private void Timer()
    {
        timerDisplay.text = string.Format("{0:00}:{1:00}", (elapsedTime / 60), (elapsedTime % 60));
    }

    public void AddScore(float ScoreToAdd)
    {
        score += ScoreToAdd;
        kill += 1;
        dna += ScoreToAdd / 10f;
    }

    public float GetVolume()
    {
        return playerStats.volumeSettings;
    }
    public void SetVolume(float volume)
    {
        playerStats.volumeSettings = volume;
    }
}
