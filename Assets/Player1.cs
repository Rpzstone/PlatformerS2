using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeedHorizontal = 5f;
    float horizontalValue;
    float jumpForce = 10f;
    [SerializeField] bool isJumping = false;
    [SerializeField] bool canJump = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        horizontalValue = Input.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && canJump)
        {

            isJumping = true;

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SpriteRenderer Player1 = GetComponent<SpriteRenderer>();
            Player1.enabled = false;
            transform.position = transform.position + new Vector3(horizontalInput * moveSpeedHorizontal * Time.deltaTime, verticalInput * Time.deltaTime, 0);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            SpriteRenderer Player1 = GetComponent<SpriteRenderer>();
            Player1.enabled = true;
            transform.position = transform.position + new Vector3(horizontalInput * moveSpeedHorizontal * Time.deltaTime, verticalInput * Time.deltaTime, 0);
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
        canJump = true;


    }
}
