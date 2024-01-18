using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, height, startPosX, startPosY;
    public GameObject cam;
    public bool isDoubleTop, isDoubleBottom;
    public float parallaxEffectX;
    public float parallaxEffectY;
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = (cam.transform.position.x * (1 - parallaxEffectX));
        float distanceX = (cam.transform.position.x * parallaxEffectX);
        float tempY = (cam.transform.position.y * (1 - parallaxEffectY));
        float distanceY = (cam.transform.position.y);



        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);


        if(tempX > startPosX + length ) { startPosX += length; }
        else if (tempX < startPosX - length ) { startPosX -= length; }
    }
}

