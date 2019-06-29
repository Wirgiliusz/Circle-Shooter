using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemyRectangle;
    public GameObject enemyWave;
    private int currentEnemy = 0;

    public float startSpawnTimer = 1.0f;
    private float spawnTimer;

    private Vector3 position;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = startSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

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

    }
}
