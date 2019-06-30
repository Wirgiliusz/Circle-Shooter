using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemyRectangle;
    public GameObject enemyWave;
    public GameObject enemyCircle;
    public GameObject player;
    public GameObject restartButton;

    public bool inGame = false;

    public bool gameModeEasy = false;

    private int currentEnemy = 0;

    public float startSpawnTimer;
    private float spawnTimer;

    public float startSpawnTimerCircle;
    private float spawnTimerCircle;

    private Vector3 position;
    private float x, y;

    public int totalScore = 0;
    private float scoreMultiplier = 1.0f;
    public int combo = 0;
    public float gameSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = startSpawnTimer;
        spawnTimerCircle = startSpawnTimerCircle;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame) {
            restartButton.SetActive(false);
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
    }
}
