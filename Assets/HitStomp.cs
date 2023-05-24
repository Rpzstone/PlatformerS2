using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStomp : MonoBehaviour
{
    public float bounce;
    private Rigidbody2D rb2D;
    PlayerHealth playerHealth;

    public bool onHit = false;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponentInParent<Rigidbody2D>();

        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag("ennemis"))
        {
            if (Vector2.Dot(Vector2.down, rb2D.velocity) >= 0.5f && !playerHealth.isInvincible)
            {
                Destroy(other.gameObject);
                rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
            }
            else if (!playerHealth.isInvincible)
            {
                playerHealth.TakeDamage(34);
            }
        }
    }
}
