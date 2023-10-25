using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject damageIndicator;
    private GameObject player;
    private PlayerProperties playerprop;

    [SerializeField] private float speed;
    private float attack;
    private float dmgModifier = 1f;
    private float knockback = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerprop = player.GetComponent<PlayerProperties>();
        attack = playerprop.Attack();
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.fixedDeltaTime * Time.timeScale, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        damageIndicator.GetComponentInChildren<TextMeshProUGUI>().text = (attack * dmgModifier).ToString();
        Instantiate(damageIndicator, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void UpdateDamage(float attackIncrease, float newmodifier)
    {
        attack = attack + attackIncrease;
        dmgModifier = newmodifier;
        return;
    }
    public float Damage()
    {
        float damage = attack * dmgModifier;
        return damage;
    }
    public float KnockBack()
    {
        return knockback;
    }
}
