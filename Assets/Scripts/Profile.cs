using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Profile : MonoBehaviour
{
    private GameMaster gm;
    public TextMeshPro tmName;
    public TextMeshPro tmTotalScore;
    public TextMeshPro tmBestScore;

    public string playerName;
    public int playerLevel;
    public int totalScore;
    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        calculateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //calculateLevel();
    }

    public void calculateLevel() {
        playerLevel = Mathf.FloorToInt(Mathf.Pow(totalScore+800000,(1f/3f))-91.8f);
        tmName.text = playerName;
        tmTotalScore.text = totalScore.ToString() + " (" + playerLevel.ToString() + "lvl)";
        tmBestScore.text = bestScore.ToString();
    }
}
