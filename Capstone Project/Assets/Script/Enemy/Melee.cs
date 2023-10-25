using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Melee : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody2D rb2d;
    private GameObject player;
    private PlayerProperties playerprop;
    private Vector3 playerposition;
    private Vector3 tempplayerposition;
    private float hp = 25f;
    private float attack = 20f;
    private float speed = 1f;
    private float elapsedtime = 0f;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerprop = player.GetComponent<PlayerProperties>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {
        elapsedtime += Time.deltaTime;
    }
    void Update()
    {
        if(elapsedtime > 300f)
        {
            hp += 25f;
            attack += 10f;
            speed += 0.25f;
        }
        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
        agent.SetDestination(playerposition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            collision.gameObject.GetComponent<PlayerProperties>().TakeDamage(attack);
            //rb2d.AddForce((transform.position - collision.transform.position ) * 2f, ForceMode2D.Force);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            float damage = collision.gameObject.GetComponent<Bullet>().Damage();
            float knockback = collision.gameObject.GetComponent<Bullet>().KnockBack();
            rb2d.AddForce((transform.position - collision.transform.position) * knockback, ForceMode2D.Force);
            TakeDamage(damage);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerProperties>().TakeDamage(attack);
        }
    }

    private void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0f)
        {
            Destroy(gameObject);

        }
        return;
    }
}
