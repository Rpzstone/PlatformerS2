using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        horizontalValue = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && canJump)
        {

            isJumping = true;

        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            gameObject.SetActive(false);
            transform.position = transform.position + new Vector3(horizontalInput * moveSpeedHorizontal * Time.deltaTime, verticalInput * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameObject.SetActive(true);
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