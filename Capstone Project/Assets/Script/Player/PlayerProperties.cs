using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    struct PlayerStats
    {

    }
    struct BulletStats
    {

    }

    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float healthPoint = 100f;
    [SerializeField] private float hpRegen = 1f;
    [SerializeField] private float attack = 10f;
    [SerializeField] private float defense = 0f;
    [SerializeField] private float rateOfFire = 1f;
    [SerializeField] private float speed = 1f;

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

    public void TakeDamage(float damage) 
    {
        if (isInvincible) { return;}
        
        healthPoint -= damage; 
        if(healthPoint <= 0)
        {
            //dead
            healthPoint = 0;
            gameObject.SetActive(false);
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
}
