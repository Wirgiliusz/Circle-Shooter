using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextMesh : MonoBehaviour
{
    TextMesh tm;
    public int scoreToAdd = 0;
    //private int i = 0;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = (GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().totalScore);
        tm = GetComponent<TextMesh>();
        tm.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = (score - scoreToAdd).ToString();
        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, tm.color.a - 0.0025f);
        if(scoreToAdd > 0) {
            scoreToAdd--;
        }
        if(tm.color.a<=0) {
            Destroy(gameObject);
        }
    }
}
