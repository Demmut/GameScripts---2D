using UnityEngine.UI;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public Image healthBar;
    public float maxHealth = 100;
    public float health;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if(health < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
