using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaterLerp : MonoBehaviour
{
    public float speed = 1.0f;
    public Color idleColor;
    public Color heatColor;
    float startTime;
    public bool heat = false;

    void Start()
    {
        startTime = Time.time;    
    }

    void Update()
    {
        if (heat)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(idleColor, heatColor, t);
        }

    }
}
