using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class swap_Player : MonoBehaviour
{
    [SerializeField] GameObject OtherPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            OtherPlayer.SetActive(true);
            OtherPlayer.transform.position = gameObject.transform.position;
            gameObject.SetActive(false);
            
          
        }
    }
}
