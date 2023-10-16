using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Camera maincam;
    private Vector3 mousepos;
    private GameObject gameManagerGO;
    private GameManager gameManager;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private GameObject cannon;

    private float speed = 1.0f;
    public float speedmod = 0;
    private float firerate = 1.0f;
    public float fireratemod = 0;

    private bool autoshoot = false;
    private float nextshoot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        maincam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2d = GetComponent<Rigidbody2D>();
        gameManagerGO = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerGO.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        Camera();
        
        maincam.transform.position = new Vector3(rb2d.position.x, rb2d.position.y, -10);
    }
    void Update()
    {
        Shoot();
    }

    private void Movement()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Horizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(Horizontal * (speed + speedmod), Vertical * (speed + speedmod));
    }
    private void Camera()
    {
        mousepos = maincam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = new Vector3(mousepos.x - transform.position.x, mousepos.y - transform.position.y,
        0);
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotz - 90);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(autoshoot)
            {
                autoshoot = false;
            }
            else
            {
                autoshoot = true;
            }
        }
        
        if ((Input.GetMouseButtonDown(0) || autoshoot) && Time.time > nextshoot)
        {
            Rigidbody2D shotbullet = Instantiate(bullet, cannon.transform.position, Quaternion.identity);
            shotbullet.transform.rotation = transform.rotation;
            nextshoot = Time.time + (1f / firerate);
        }
    }
    public bool AutoShoot()
    {
        return autoshoot;
    }
}
