using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private float timelimit = 1f;

    void Update()
    {
        transform.position += new Vector3(0f, 1f * Time.deltaTime, 0f);
        timelimit -= Time.deltaTime;
        if(timelimit <= 0f) { Destroy(gameObject); }
    }
}
