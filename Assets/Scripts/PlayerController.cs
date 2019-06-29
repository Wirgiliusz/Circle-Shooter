using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject particleEffectDeath;

    public float baseRotationSpeed = 300.0f;    // rotation speed of the player
    private float rotationSpeed;
    public float sprintMultiplier = 1.5f;       // rotation speed multiplier for faster spinning
    public int health = 3;                      // health of the player


    // Start is called before the first frame update
    void Start()
    {
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

        if(health == 2) {
            GetComponent<SpriteRenderer>().color = new Color(0.93f,0.93f,0.93f);
        }
        else if(health == 1) {
            GetComponent<SpriteRenderer>().color = new Color(0.85f,0.85f,0.85f);
        }

    }


    // Function allowing making damage to the player
    public void TakeDamage(int damage) {
        health -= damage;
    }
}
