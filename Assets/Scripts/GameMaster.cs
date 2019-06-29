using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemyRectangle;
    public GameObject enemyWave;
    public GameObject enemyCircle;

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

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = startSpawnTimer;
        spawnTimerCircle = startSpawnTimerCircle;
    }

    // Update is called once per frame
    void Update()
    {
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
            spawnTimer = startSpawnTimer;
        }

        if(spawnTimerCircle <= 0) {
            GameObject.Instantiate(enemyCircle);
            spawnTimerCircle = startSpawnTimerCircle;
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

        totalScore = totalScore + Mathf.RoundToInt(score*scoreMultiplier);
    }
}
