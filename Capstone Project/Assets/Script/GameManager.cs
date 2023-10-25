using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerMovement player;
    private PlayerProperties playerProperties;

    [SerializeField] private Slider playerHP;
    [SerializeField] private Slider PlayerEXP;

    public GameObject autoShoot;
    // Start is called before the first frame update
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
}
