using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject particleEffectDeath;
    public GameObject particleEffectDamage;
    private Shake shake;
    public GameObject playerHealth4;
    public GameObject playerHealth3;
    public GameObject playerHealth2;
    public GameObject playerHealth1;

    public float baseRotationSpeed;    // rotation speed of the player
    private float rotationSpeed;
    public float sprintMultiplier;       // rotation speed multiplier for faster spinning
    public int health;                      // health of the player

    private bool gameModeEasy;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        gameModeEasy = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().gameModeEasy;
        rotationSpeed = baseRotationSpeed;  // setting rotation speed
    }


    // Update is called once per frame
    void Update()
    {
        // checking if player is dead
        if(health <= 0) {
            Instantiate(particleEffectDeath, transform.position, Quaternion.identity);
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
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().combo = 0;
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
}
