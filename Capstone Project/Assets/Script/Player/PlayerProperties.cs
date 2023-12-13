using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public class PlayerStats
    {

    }
    
    struct BulletStats
    {

    }
    List<float> stats = new List<float>();

    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float healthPoint = 100f;
    [SerializeField] private float hpRegen = 1f;
    [SerializeField] private float attack = 10f;
    [SerializeField] private float defense = 0f;
    [SerializeField] private float rateOfFire = 1f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float experience = 0f;
    [SerializeField] private float maxExperience = 100f;
    [SerializeField] private int level = 1;

    private bool isInvincible = false;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float Health() { return healthPoint;}
    public float MaxHP() { return maxHP;}
    public float HPRegen() { return hpRegen;}
    public float Attack(){ return attack;}
    public float Defense() { return defense;}
    public float RateOfFire() { return rateOfFire;}
    public float Speed() { return speed;}
    public float Experience() { return experience;}
    public float MaxExperience() { return maxExperience; }
    public int Level() { return level;}

    public void TakeDamage(float damage) 
    {
        if (isInvincible) { return;}
        
        healthPoint -= damage; 
        if(healthPoint <= 0)
        {
            //dead
            healthPoint = 0;
            gameManager.UpdateHP(healthPoint);
            gameObject.SetActive(false);
            gameManager.DeathScreen();
            Time.timeScale = 0f;
            return;
        }
        StartCoroutine(Invincible(1f));
        gameManager.UpdateHP(healthPoint);
        return;
    }
    IEnumerator Invincible(float Duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(Duration);
        isInvincible = false;
    }
    public void GetEXP(float exp)
    {
        experience += exp;
        if(experience >= maxExperience)
        {
            experience -= maxExperience;
            level += 1;
            maxExperience += 10;
            LevelUp();
        }
        gameManager.UpdateEXP(experience);
    }

    private void LevelUp()
    {
        Time.timeScale = 0f;
        gameManager.levelUpScreen.SetActive(true);
        Debug.Log("Level UP!!!");
        
        
    }
    IEnumerator LevelUpPause()
    {
        isInvincible = true;
        
        isInvincible = false;
        yield return new WaitForSeconds(1f);
    }
    public void StatsUpgrade(string stat, float value)
    {
        if(stat == nameof(attack)) attack += value;
        else if(stat == nameof(defense)) defense += value;
        else if (stat == nameof(hpRegen)) hpRegen += value;
        else if (stat == nameof(healthPoint)) healthPoint += value;
        else if (stat == nameof(maxHP)) maxHP += value;
        else if (stat == nameof(rateOfFire)) rateOfFire += value;
        else if (stat == nameof(speed)) speed += value;
        else Console.WriteLine("Stat" + stat + "not found.");

    }
}
