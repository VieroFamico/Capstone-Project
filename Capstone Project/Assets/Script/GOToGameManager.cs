using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GOToGameManager : MonoBehaviour
{
    public GameObject playerGO;
    public PlayerMovement player;
    public PlayerProperties playerProperties;

    public Slider playerHP;
    public Slider playerEXP;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    public TextMeshProUGUI playerLevel;

    public GameObject autoShoot;
    public GameObject levelUpScreen;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    private GameManager gameManager;
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        ResetGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGameManager()
    {
        gameManager.playerGO = playerGO;
        gameManager.player = player;
        gameManager.playerProperties = playerProperties;   
        gameManager.playerHP = playerHP;
        gameManager.playerEXP = playerEXP;
        gameManager.deathScreen = deathScreen;
        gameManager.playerLevel = playerLevel;
        gameManager.autoShoot = autoShoot;
        gameManager.levelUpScreen = levelUpScreen;
        gameManager.option1 = option1;
        gameManager.option2 = option2;  
        gameManager.option3 = option3;
    }
}
