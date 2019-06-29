using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject particleEffectDeath;

    public float baseRotationSpeed;    // rotation speed of the player
    private float rotationSpeed;
    public float sprintMultiplier;       // rotation speed multiplier for faster spinning
    public int health;                      // health of the player

    private bool gameModeEasy;
    // Start is called before the first frame update
    void Start()
    {
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
        

        if(health == 2) {
            GetComponent<SpriteRenderer>().color = new Color(0.93f,0.93f,0.93f);
        }
        else if(health == 1) {
            GetComponent<SpriteRenderer>().color = new Color(0.85f,0.85f,0.85f);
        }

    }


    // Function allowing making damage to the player
    public void TakeDamage(int damage) {
        GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().combo = 0;
        health -= damage;
    }
}
