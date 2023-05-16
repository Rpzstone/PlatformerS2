using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInterface : MonoBehaviour
{
    public int score=0;
    TextMeshProUGUI textMeshPro;
    private GameObject player2Ref;
    Animator an;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        player2Ref = GameObject.FindGameObjectWithTag("Player2");
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score++;
        textMeshPro.text = "Score : "+score.ToString();
        if(score == 1)
        {
            player2Ref.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (score == 2)
        {
            player2Ref.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (score == 3)
        {
            player2Ref.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        if (score == 4)
        {
            player2Ref.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
