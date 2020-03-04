using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine;

public class lightning : MonoBehaviour
{
    Light2D globalLight = null;
    float lightningTimer;
    public float lightningTimerRangeMin = 5;
    public float lightningTimerRangeMax = 20;

    void Start()
    {
        lightningTimer = Time.time + 3f;
        globalLight = GetComponent<Light2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time > lightningTimer)
        {
            globalLight.intensity = 5f;
            lightningTimer += Random.Range(lightningTimerRangeMin, lightningTimerRangeMax);
        }else
        {
            globalLight.intensity -= (globalLight.intensity - 0.3f) * .1f;
        }
    }
}
