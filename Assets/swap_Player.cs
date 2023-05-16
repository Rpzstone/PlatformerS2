using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class swap_Player : MonoBehaviour
{
    [SerializeField] GameObject OtherPlayer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent< Animator > ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("Fire1"))
        {
           /* animator.SetBool("changeChara", !animator.GetBool("changeChara"));*/
            OtherPlayer.SetActive(true);
            OtherPlayer.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
        }
    }
}
