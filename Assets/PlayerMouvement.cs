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
    Animator an;
    SpriteRenderer sr;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalValue = Input.GetAxis("Horizontal");

        if (horizontalValue > 0) sr.flipX = false;
        if (horizontalValue < 0) sr.flipX = true;

        
        an.SetFloat("speed",Mathf.Abs(horizontalValue));
        

        if (Input.GetButtonDown("Jump") && canJump)
        {
            an.SetBool("jump", true);
            canJump = true;
            isJumping = true;

        }
       
        //Debug.Log(horizontalValue);
    }
    void FixedUpdate()
    {
        if (isJumping)
        {
            an.SetBool("jump", true);
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
            an.SetBool("jump", false);
        }
    }
}
