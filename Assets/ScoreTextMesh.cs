using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextMesh : MonoBehaviour
{
    TextMesh tm;
    public int scoreToAdd = 0;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        tm.text = (GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().totalScore - scoreToAdd).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tm.text = (GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().totalScore - scoreToAdd).ToString();
        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, tm.color.a - 0.005f);
        if(scoreToAdd > 0) {
            scoreToAdd--;
        }
    }
}
