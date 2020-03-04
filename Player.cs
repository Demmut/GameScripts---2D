using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    Animator anim;
    Input_Controller inputController;
    float timer = 0;


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        inputController = GetComponent<Input_Controller>();
        health = maxHealth;
    }

    private void Update()
    {
        if(timer != 0)
        if(Time.time > timer)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }



    public new void TakeDamage(int damage)
    {
        health = health - damage;

        healthBar.fillAmount = health / maxHealth;

        if(health<=0)
        {
            anim.SetBool("Die", true);
            inputController.enabled = false;
            if(timer == 0)
                timer = Time.time + 3f;
        }
        else
        {
            anim.SetTrigger("Damaged");
        }
    }
}
