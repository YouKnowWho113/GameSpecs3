using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{

    public float speed = 60f;

    float startX;
    float startZ;

    void Start()
    {
        startX = transform.localEulerAngles.x;
        startZ = transform.localEulerAngles.z;
    }

    void Update()
    {
        float y = transform.localEulerAngles.y;
        y += speed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(startX, y, startZ);
    }
}