using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    // Enemies GameObjects
    public GameObject enemyRectangle;
    public GameObject enemyWave;
    public GameObject enemyCircle;

    // Player GameObject
    public GameObject player;

    // Restart button GameObject
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject backButton;
    public GameObject scoreText;

    // Player Profile 
    public GameObject profile;
    public GameObject statistics;
    public Profile profileScript;

    // game settings
    public bool inGame = false;
    public bool gameModeEasy = false;
    public int totalScore = 0;
    private float scoreMultiplier = 1.0f;
    public int combo = 0;
    public float gameSpeed = 1.0f;

    // Enemy spawning
    private int currentEnemy = 0;   // to alternate between enemies
    public float startSpawnTimer;   // spawn cooldown for enemies
    private float spawnTimer;
    public float startSpawnTimerCircle; // spawn cooldown for circle enemies
    private float spawnTimerCircle;


    // Start is called before the first frame update
    void Start()
    {
        profileScript = profile.GetComponent<Profile>();
        spawnTimer = startSpawnTimer;
        spawnTimerCircle = startSpawnTimerCircle;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame) {
            restartButton.SetActive(false);
            menuButton.SetActive(false);
            //statistics.SetActive(false);
            scoreText.SetActive(false);

            spawnTimer -= Time.deltaTime;
            spawnTimerCircle -= Time.deltaTime;

            if(spawnTimer <= 0) {
                if(currentEnemy == 0) {
                    GameObject.Instantiate(enemyRectangle);
                    currentEnemy = 1;
                }
                else if (currentEnemy == 1) {
                    GameObject.Instantiate(enemyWave);
                    currentEnemy = 0;
                }
                spawnTimer = startSpawnTimer - 0.15f*gameSpeed;
            }

            if(spawnTimerCircle <= 0) {
                GameObject.Instantiate(enemyCircle);
                spawnTimerCircle = startSpawnTimerCircle - 0.2f*gameSpeed;
            }
        }
        else {
            Destroy(GameObject.FindGameObjectWithTag("EnemyRectangle"));
            Destroy(GameObject.FindGameObjectWithTag("EnemyWave"));
            Destroy(GameObject.FindGameObjectWithTag("EnemyCircle"));
        }

    }

    public void addScore(int score) {
        if(combo < 5) {
            scoreMultiplier = 1.0f;
        }
        else if(combo >= 5 && combo < 10) {
            scoreMultiplier = 1.2f;
        }
        else if(combo >= 10 && combo < 15) {
            scoreMultiplier = 1.5f;
        }
        else if (combo >= 15) {
            scoreMultiplier = 2.0f;
        }

        totalScore = totalScore + Mathf.RoundToInt(score*scoreMultiplier*gameSpeed);

        if(totalScore < 1000) {
            gameSpeed = 1.0f;
        }
        else if(totalScore >= 1000 && totalScore < 3000) {
            gameSpeed = 1.2f;
        }
        else if(totalScore >= 3000 && totalScore < 5000) {
            gameSpeed = 1.5f;
        }
        else if(totalScore >= 5000 && totalScore < 10000) {
            gameSpeed = 2.0f;
        }
        else if(totalScore >= 10000 && totalScore < 15000) {
            gameSpeed = 2.5f;
        }
        else if(totalScore >= 15000) {
            gameSpeed = 3.0f;
        }
    }

    public void SetInGame(bool set) {
        inGame = set;
    }
    public void changeGamemode() {
        if(gameModeEasy == true) {
            gameModeEasy = false;
        }
        else {
            gameModeEasy = true;
        }
    }

    public void restartGame() {
        inGame = true;
        Instantiate(player);
        totalScore = 0;
        combo = 0;
        scoreMultiplier = 1.0f;
        gameSpeed = 1.0f;
    }

    public void toMenu() {
        Instantiate(player);
        menuButton.SetActive(false);
        totalScore = 0;
        combo = 0;
        scoreMultiplier = 1.0f;
        gameSpeed = 1.0f;
    }
}
