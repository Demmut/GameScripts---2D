using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 2f;
    public int damage = 20;
    public Rigidbody2D rb;
    float deathTimer;
    Transform target;
    Vector2 pos;

    GameObject[] enemies;

    void Start()
    {
        deathTimer = Time.time + 2f;
        enemies = GameObject.FindGameObjectsWithTag("NPC");
        target = GetClosestEnemy(enemies);
        rb.velocity = (target.position - transform.position).normalized * 15f;
    }


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        Entity entity = hitInfo.GetComponent<Entity>();
        Debug.Log(hitInfo.name);

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (entity != null && hitInfo.GetComponent<AylinBossAI>() == null)
        {
            entity.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (Time.time > deathTimer)
            Destroy(gameObject);
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

}