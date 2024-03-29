using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public float invincibilityFlashDelay = 0.2f;

    public BarreDeVie healthBar;

    [SerializeField] GameObject ennemis;

    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        graphics = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // test pour voir si ca fonctionne
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(34);
        }

     
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;  // si on prends des degats ont retire de la vie a la vie actuelle
            healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie

            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());


        }
    }
    
    public void Die()
    {
        if (currentHealth <= 0)
        {
            FindObjectOfType<LevelManager>().Restart();
        }
        Debug.Log("le joueur est �limin�");
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
        Debug.Log("Coroutine1");
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
        Debug.Log("Coroutine2");
    }
}
