using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject particleEffectDeath;
    public GameObject particleEffectDamage;
    private Shake shake;
    public GameObject playerHealth4;
    public GameObject playerHealth3;
    public GameObject playerHealth2;
    public GameObject playerHealth1;
    private GameMaster gm;

    public float baseRotationSpeed;    // rotation speed of the player
    private float rotationSpeed;
    public float sprintMultiplier;       // rotation speed multiplier for faster spinning
    public int health;                      // health of the player

    private float keyHeldTime = 0;

    private bool gameModeEasy;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        gameModeEasy = gm.gameModeEasy;
        rotationSpeed = baseRotationSpeed;  // setting rotation speed
    }


    // Update is called once per frame
    void Update()
    {
        gameModeEasy = gm.gameModeEasy;

        // checking if player is dead
        if(health <= 0) {
            Instantiate(particleEffectDeath, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioManager>().playSound("playerExplosion");
            gm.inGame = false;
            transferScore();
            //gm.statistics.SetActive(true);
            gm.profileScript.setShowingStatistics(true);
            gm.restartButton.SetActive(true);
            gm.menuButton.SetActive(true);
            gm.scoreText.GetComponent<TextMeshProUGUI>().text = gm.totalScore.ToString();
            gm.scoreText.SetActive(true);
            Destroy(gameObject);
        }

        // - - - Player controlls - - - //
        if(!gameModeEasy) {
            // rotating left (<-) or right (->)
            if(Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(0,0,-rotationSpeed*Time.deltaTime);
            }
            // faster rotation (shift)
            if(Input.GetKey(KeyCode.LeftShift)) {
                rotationSpeed = baseRotationSpeed * sprintMultiplier;
            }
            else {
                rotationSpeed = baseRotationSpeed;
            }
        }
        else {
            Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.up = mouseScreenPosition - (Vector2)transform.position;
        }

        if(Input.GetKey(KeyCode.R) && gm.inGame == true) {
            keyHeldTime += Time.deltaTime;
            if(keyHeldTime >= 0.5f && health == 5) {
                health -= 1;
            }
            else if(keyHeldTime >= 0.7f && health == 4) {
                health -= 1;
            }
            else if(keyHeldTime >= 0.9f && health == 3) {
                health -= 1;
            }
            else if(keyHeldTime >= 1.0f && health == 2) {
                health -= 1;
            }
            else if(keyHeldTime >= 1.1f && health == 1) {
                health -= 1;
            }
        }
        else {
            keyHeldTime = 0;
        }
        
        if(health == 4 && !GameObject.FindGameObjectWithTag("PlayerHealth4")) {
            Instantiate(playerHealth4, transform);
        }
        if(health == 3 && !GameObject.FindGameObjectWithTag("PlayerHealth3")) {
            Instantiate(playerHealth3, transform);
        }
        if(health == 2 && !GameObject.FindGameObjectWithTag("PlayerHealth2")) {
            Instantiate(playerHealth2, transform);
            GetComponent<SpriteRenderer>().color = new Color(0.93f,0.93f,0.93f);
        }
        if(health == 1 && !GameObject.FindGameObjectWithTag("PlayerHealth1")) {
            Instantiate(playerHealth1, transform);
            GetComponent<SpriteRenderer>().color = new Color(0.85f,0.85f,0.85f);
        }

    }


    // Function allowing making damage to the player
    public void TakeDamage(int damage) {
        Instantiate(particleEffectDamage, transform.position, Quaternion.identity);
        shake.CamShake();
        gm.combo = 0;
        health -= damage;
        if(health == 4) {
            Instantiate(playerHealth4, transform);
        }
        if(health == 3) {
            Instantiate(playerHealth3, transform);
        }
        if(health == 2) {
            Instantiate(playerHealth2, transform);
            GetComponent<SpriteRenderer>().color = new Color(0.93f,0.93f,0.93f);
        }
        if(health == 1) {
            Instantiate(playerHealth1, transform);
            GetComponent<SpriteRenderer>().color = new Color(0.85f,0.85f,0.85f);
        }
    }

    private void transferScore() {
        gm.profileScript.totalScore += gm.totalScore;
        if(gm.totalScore > gm.profileScript.bestScore) {
            gm.profileScript.bestScore = gm.totalScore;
        }
        gm.profileScript.calculateLevel();
    }
}
