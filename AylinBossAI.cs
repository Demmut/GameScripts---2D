using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AylinBossAI : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Rigidbody2D rb;
    Animator anim;
        public Transform firePoint;
        public GameObject bulletPrefab;

    float changeTargetTimer;

    [SerializeField]
    float moveForce = .1f;
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField]
    float maxVelocity = 10f;

    public float shootingInterval = 10;
    float shootingTime;
    public float repelRange = .5f;
    public float repelAmount = 1.5f;

    float absVelX;


    Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
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



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        shootingTime = shootingInterval;
        changeTargetTimer = Time.time + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > changeTargetTimer || playerRigidbody == null)
        {
            changeTargetTimer = Time.time + 5f;
            playerRigidbody = GetClosestEnemy().GetComponent<Rigidbody2D>();
        }

        if (Time.time > shootingTime)
                {
                    Shoot();
                    shootingTime = Time.time + shootingInterval + Random.value * 2 - 1;
                }
        
        absVelX = Mathf.Abs(rb.velocity.x);
        if (Vector2.Distance(rb.position, playerRigidbody.position) < repelRange)
        {
            rb.velocity = rb.velocity / repelAmount;
        }
        else
        {
            if (absVelX < maxVelocity)
                rb.AddForce((playerRigidbody.position - rb.position) * moveForce, ForceMode2D.Impulse);
        }


        if (rb.velocity.x > -0.2)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        anim.SetFloat("MoveX", absVelX);
    }



    
        void Shoot()
        {
            anim.SetTrigger("Attack");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    
}
