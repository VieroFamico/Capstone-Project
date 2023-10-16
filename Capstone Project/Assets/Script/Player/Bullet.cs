using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        transform.Translate(new Vector3(0, speed * Time.fixedDeltaTime * Time.timeScale, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
