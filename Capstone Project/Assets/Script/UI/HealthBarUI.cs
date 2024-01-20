using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerProperties playerProperties;
    private Slider healthBarSlider;
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerProperties = playerGO.GetComponent<PlayerProperties>();
        healthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerGO != null)
        {
            healthBarSlider.maxValue = playerProperties.MaxHP();
            healthBarSlider.value = playerProperties.Health();
            healthBarSlider.GetComponentInChildren<TextMeshProUGUI>().text = playerProperties.Health().ToString();
        }
    }
}
