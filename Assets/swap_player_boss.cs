using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class swap_Player_boss : MonoBehaviour
{
    [SerializeField] GameObject OtherPlayer;
    private ScoreInterface Score_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("Fire1"))
        {
            /* animator.SetBool("changeChara", !animator.GetBool("changeChara"));*/
            OtherPlayer.SetActive(true);
            if (OtherPlayer.tag == "Player2")
            {
                OtherPlayer.GetComponent<Animator>().SetLayerWeight(Score_Text.score, 1);
            }
            OtherPlayer.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
        }
    }
}