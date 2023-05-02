using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeedHorizontal = 5f;
    float horizontalValue;
    float jumpForce = 6F;
    public float bounce;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJump = false;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalValue = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = true;
            isJumping = true;

        }
       
        //Debug.Log(horizontalValue);
    }
    void FixedUpdate()
    {
        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
        rb.velocity = new Vector2(horizontalValue * moveSpeedHorizontal, rb.velocity.y);
        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "sol")
        {
            canJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision " + collision.gameObject.name + " " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("ennemis"))
        {
            if (rb.velocity.y < 0)
            {
                // Destruction ennemi
                Debug.Log("destruction");
                collision.gameObject.GetComponent<Degatboite>().TakeDamage();
                
            } else
            {
                // Dommage
                Debug.Log("dommage");
            }
        }
    }







}
