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

    public bool hidingStatistics = false;
    public bool showingStatistics = false;

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
        if(hidingStatistics) {
            hideStatistics();
        }
        if(showingStatistics) {
            showStatistics();
        }
    }

    public void calculateLevel() {
        playerLevel = Mathf.FloorToInt(Mathf.Pow(totalScore+800000,(1f/3f))-91.8f);
        tmName.text = playerName;
        tmTotalScore.text = totalScore.ToString() + " (" + playerLevel.ToString() + "lvl)";
        tmBestScore.text = bestScore.ToString();
    }

    private void hideStatistics() {
        if(tmName.color.a > 0) {
            tmName.color = new Color(tmName.color.r,tmName.color.g,tmName.color.b,tmName.color.a - 0.005f);
            tmTotalScore.color = new Color(tmTotalScore.color.r,tmTotalScore.color.g,tmTotalScore.color.b,tmTotalScore.color.a - 0.005f);
            tmBestScore.color = new Color(tmBestScore.color.r,tmBestScore.color.g,tmBestScore.color.b,tmBestScore.color.a - 0.005f);
        }
        else {
            //gameObject.SetActive(false);
            hidingStatistics = false;
        }
    }
    public void setHidingStatistics(bool var) {
        hidingStatistics = var;
    }

    public void showStatistics() {
        //gameObject.SetActive(true);
        if(tmName.color.a < 1) {
            tmName.color = new Color(tmName.color.r,tmName.color.g,tmName.color.b,tmName.color.a + 0.005f);
            tmTotalScore.color = new Color(tmTotalScore.color.r,tmTotalScore.color.g,tmTotalScore.color.b,tmTotalScore.color.a + 0.005f);
            tmBestScore.color = new Color(tmBestScore.color.r,tmBestScore.color.g,tmBestScore.color.b,tmBestScore.color.a + 0.005f);
        }
        else {
            showingStatistics = false;
        }
    }
    public void setShowingStatistics(bool var) {
        showingStatistics = var;
    }
}
