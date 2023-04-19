using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degatboite : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.transform.name == "Player1")
        {

            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(5);


        }
        if (collision.transform.name == "Player2")
        {

            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(5);


        }
        */

    }

    public void TakeDamage()
    {
        Debug.Log("TakeDamage");
    }
}
