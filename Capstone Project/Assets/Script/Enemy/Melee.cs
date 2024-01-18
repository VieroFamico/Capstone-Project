using System;
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
    private GameManager gameManager;
    private Vector3 playerposition;
    private Vector3 tempplayerposition;




    private float hp = 25f;
    private float attack = 20f;
    private float speed = 1f;
    private int expDropped = 1;
    [SerializeField] private GameObject exp;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerprop = player.GetComponent<PlayerProperties>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }
    private void FixedUpdate()
    {

    }
    void Update()
    {
        if(gameManager.ElapsedTime() > 300f)
        {
            hp += 25f;
            attack += 10f;
            speed += 0.25f;
        }
        if(player != null)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
        rb2d.velocity = Vector2.zero;
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
            rb2d.AddForce((transform.position - collision.transform.position) * knockback, ForceMode2D.Impulse);
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
            float scoreMultiplier = (50 + (gameManager.ElapsedTime() / 3)) / 100;
            gameManager.AddScore(10 * scoreMultiplier);
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        return;
    }
    
    public void AddStats(float HP, float Attack, float Speed, int ExpDropped)
    {
        hp += HP;
        attack += Attack;
        speed += Speed;
        expDropped += ExpDropped;
    }
}
