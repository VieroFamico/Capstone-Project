using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private float exp = 10f;
    [SerializeField] private float pickUpRange = 5f;
    [SerializeField] private float expSpeed = 5f;

    private GameObject player;
    void Start()
    {
        pickUpRange = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>().PickUpRange();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < pickUpRange)
        {
            Vector2 directionToPlayer = (Vector2)player.transform.position - (Vector2)transform.position;

            Vector2 normalizedDirection = directionToPlayer.normalized;

            // Calculate the target position by adding the normalized direction to the current position
            Vector2 targetPosition = (Vector2)transform.position + normalizedDirection * expSpeed * Time.deltaTime;

            // Move the object toward the player using Vector2.Lerp
            transform.position = Vector2.Lerp((Vector2)transform.position, targetPosition, expSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerProperties>().GetEXP(exp);
            Destroy(gameObject);
        }
    }
}
