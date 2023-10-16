using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject playerGO;
    private PlayerMovement player;

    public GameObject autoShoot;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        player = playerGO.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.AutoShoot()) autoShoot.SetActive(true);
        else autoShoot.SetActive(false);
    }
}
