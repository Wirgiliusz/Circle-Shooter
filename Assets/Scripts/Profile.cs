using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    private GameMaster gm;

    public string playerName;
    public int playerLevel;
    public int totalScore;
    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculateLevel();
    }

    public void calculateLevel() {
        playerLevel = Mathf.FloorToInt(Mathf.Pow(totalScore+800000,(1f/3f))-91.8f);
    }
}
