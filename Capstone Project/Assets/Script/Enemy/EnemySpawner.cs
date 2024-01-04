using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;

    [SerializeField] private GameObject melee;
    [SerializeField] private float spawnrate = 1;
    private float time = 0f;
    private float elapsedtime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(elapsedtime < 45f)
        {
            if (10f < time)
            {
                Spawn();
            }
        }
        else if(elapsedtime < 90f)
        {
            if (5f < time)
            {
                Spawn();
            }
        }
        else
        {
            if (2f < time)
            {
                Spawn();
            }
        }

        time += (spawnrate * Time.fixedDeltaTime);
        elapsedtime = gameManager.ElapsedTime();
    }

    private void Spawn()
    {
        int posOrNegX = Random.Range(0, 2) * 2 - 1;
        int posOrNegY = Random.Range(0, 2) * 2 - 1;
        float x = Random.Range(player.transform.position.x - 15f, player.transform.position.x - 10f);
        float y = Random.Range(player.transform.position.y - 5f, player.transform.position.y - 10f);

        GameObject newMeleeGO = Instantiate(melee, new Vector3(x * posOrNegX, y * posOrNegY, 0), Quaternion.identity);
        Melee newMelee = GetComponent<Melee>();
        time = 0;
        if (elapsedtime > 45f && elapsedtime < 90f)
        {
            newMelee.AddStats(25f, 10f, 0.25f);
        }
        else if (elapsedtime > 45f && elapsedtime < 135f)
        {
            newMelee.AddStats(25f, 10f, 0.25f);
            newMelee.AddStats(25f, 10f, 0.25f);
        }
    }
}
