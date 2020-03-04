using UnityEngine;

public class BasicAI : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Rigidbody2D rb;
    Transform BossTransform = null;
    Animator anim;
    float timer;
/*    public Transform firePoint;
    public GameObject bulletPrefab;*/


    [SerializeField]
    float moveForce = .1f;
    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    float maxVelocity = 10f;


/*    public float shootingInterval = 10;
    float shootingTime;*/
    public float repelRange = .5f;
    public float repelAmount = .1f;

    float absVelX;

    void Start()
    {
        timer = Time.time + Random.Range(2, 10);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        BossTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
/*        shootingTime = shootingInterval;*/
    }

    // Update is called once per frame
    void Update()
    {
/*
        if(Time.time > shootingTime)
        {
            Shoot();
            shootingTime = Time.time + shootingInterval + Random.value * 2 - 1;
        }
*/

        if(Time.time > timer)
        {
            Debug.Log("!!");
            timer = Time.time + Random.Range(2, 10);
            rb.AddForce(Vector2.up * 1 * jumpForce, ForceMode2D.Impulse);//moves the sprite
            anim.SetTrigger("Jump");
        }

        absVelX = Mathf.Abs(rb.velocity.x);
        if(BossTransform != null)
        if (Vector2.Distance(rb.position, BossTransform.position) < repelRange * 1.5)
        {
            if (absVelX < maxVelocity)
                rb.AddForce(new Vector2(transform.position.x - BossTransform.position.x, 0) * moveForce, ForceMode2D.Impulse);
        }
        else if ( Vector2.Distance(rb.position, playerRigidbody.position) < repelRange)
        {
            rb.velocity = rb.velocity * repelAmount;
        } else 
        {
            if (absVelX < maxVelocity)
                rb.AddForce((playerRigidbody.position - rb.position) * moveForce, ForceMode2D.Impulse);
        }

        


        if (rb.velocity.x > -0.2)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        anim.SetFloat("MoveX", absVelX);
    }



/*
    void Shoot()
    {
        anim.SetTrigger("Attack");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
*/
}
