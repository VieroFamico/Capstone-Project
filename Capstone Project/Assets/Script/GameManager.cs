using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerMovement player;
    private PlayerProperties playerProperties;

    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider PlayerEXP;
    [SerializeField] private GameObject deathScreen;

    public GameObject autoShoot;
    public GameObject levelUpScreen;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.GetComponent<PlayerMovement>();
        playerProperties = playerGO.GetComponent<PlayerProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.AutoShoot()) autoShoot.SetActive(true);
        else autoShoot.SetActive(false);
    }

    public void UpdateHP(float HP)
    {
        playerHP.value = HP;
        playerHP.GetComponentInChildren<TextMeshProUGUI>().text = HP.ToString();
    }
    public void UpdateEXP(float EXP)
    {
        PlayerEXP.value = EXP;
        playerHP.GetComponentInChildren<TextMeshProUGUI>().text = EXP.ToString();
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
    
    public void DeathScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
