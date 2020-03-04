using UnityEngine;
using System.Collections.Generic;

public class InsideOfBullet : MonoBehaviour
{
    protected List<GameObject> insideMe = new List<GameObject>();

    public GameObject target = null;
    float x;
    int rand = -1;

    private void OnTriggerEnter2D(Collider2D e)
    {
        if (e.gameObject != null)
        {
            if(e.gameObject.GetComponent<Entity>() != null)
                if(e.gameObject.tag != "Enemy")
                    if (!this.insideMe.Contains(e.gameObject))
                    {
                        this.insideMe.Add(e.gameObject);
                    }
        }
    }

    private void Start()
    {
        x = Time.time+.5f;
    }

    private void Update()
    {
        if(target == null && insideMe.Count>0)
        {
            rand = Random.Range(0, insideMe.Count - 1);
        }
        if(Time.time > x)
        {
            if(target == null)
            {
                target = insideMe[rand];
            }
        }
    }

}