using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private ScoreInterface Score_Text;
    private bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        Score_Text = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ScoreInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player2" && !activated) {
            activated = true;
            Score_Text.updateScore();
            Destroy(gameObject);
        }
    }
}
