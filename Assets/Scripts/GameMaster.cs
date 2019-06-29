using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemyRectangle;
    public GameObject enemyWave;
    public GameObject enemyCircle;

    private int currentEnemy = 0;

    public float startSpawnTimer;
    private float spawnTimer;

    public float startSpawnTimerCircle;
    private float spawnTimerCircle;

    private Vector3 position;
    private float x, y;

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
}
