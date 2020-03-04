using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeOut : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = Time.time + Random.value * 20;
    }

    void Update()
    {
        if (Time.time > timer)
            Destroy(gameObject);
    }
}
