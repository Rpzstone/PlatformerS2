using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInterface : MonoBehaviour
{
    public int score=0;
    TextMeshProUGUI textMeshPro;
    private GameObject player2Ref;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        player2Ref = GameObject.FindGameObjectWithTag("Player2");
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
            player2Ref.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
