using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data")]
public class PlayerStats : ScriptableObject
{
    public float maxHP = 100f;
    public float healthPoint = 100f;
    public float hpRegen = 1f;
    public float attack = 10f;
    public float defense = 0f;
    public float rateOfFire = 1f;
    public float speed = 1f;
    public float experience = 0f;
    public float maxExperience = 100f;
    public int level = 1;

    public int DNA = 0;
    public int maxHPUpgrade = 0;
    public int hpRegenUpgrade = 0;
    public int attackUpgrade = 0;
    public int defenseUpgrade = 0;
    public int rateOfFireUpgrade = 0;
    public int speedUpgrade = 0;

}
