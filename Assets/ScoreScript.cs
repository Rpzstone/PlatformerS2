using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI Score_Text;
    private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        Score_Text.text = "Score : " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D asta)
    {
        if (asta.tag == "Fragments")
        {
            ScoreNum ++;
            Destroy(asta.gameObject);
            Score_Text.text = "Score" + ScoreNum;
        }
    }


}
