using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleController : MonoBehaviour
{
    public GameObject destroyParticleEffect;
    private Transform targetTransform;  // transform of the enemy target
    private Vector2 direction;          // enemy direction vector
    private Vector2 up;

    public int health;        // enemy health
    public float startSpeed;     // enemy speed
    private float speed;
    public float startRevolvingSpeed;
    private float revolvingSpeed;
    private int revolvingDirection = 0;
    public int damage;        // enemy damage
    public int score;

    public float raycastDistance;   // distance of the raycast from the enemy
    public float raycastRadius;      // radius of the raycast from the enemy
    public LayerMask whatIsSolid;           // defines layers that are solid for the enemy

    private Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed + Random.Range(-3,3);
        revolvingSpeed = startRevolvingSpeed + Random.Range(-0.03f,0.03f);
        while(revolvingDirection == 0) {
            revolvingDirection = Random.Range(-1,2);
        }

        position.x = Random.Range(-70, 70);
        if(position.x >= 40 || position.x <= -40) {
            position.y = Random.Range(-50, 50);
        }
        else {
            position.y = Random.Range(-50, 50);
            if(position.y >= 25 || position.y <= -25) {
                position.x = Random.Range(-70, 70);
            }
            else {
                Destroy(gameObject);
            }
        }

        transform.position = position;
        if(GameObject.FindGameObjectWithTag("Player") != null) {
            targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // finds transform of the target (Player)
            direction = targetTransform.position - transform.position;  // sets direction to face player
            transform.up = direction;   // and rotates
        }

        up = new Vector2(-direction.y, direction.x);
        up.Normalize();
        up = up*revolvingSpeed;
    }


    // Update is called once per frame
    void Update()
    {
        // checking if enemy is dead
        if(health <= 0) {
            GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().addScore(score);
            Destroy(gameObject);
        }

        RaycastHit2D hitInfo = Physics2D.CircleCast(transform.position, raycastRadius, transform.up, raycastDistance, whatIsSolid); // raycasts circle of raycastRadius and collets collision information
        if(hitInfo.collider != null) {  // if there was collision
            if(hitInfo.collider.CompareTag("Player")) { // with GameObject tagged "Player"
                hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);   // take it script component and use TakeDamage function
            }
            Instantiate(destroyParticleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(GameObject.FindGameObjectWithTag("Player") != null) {
            direction = targetTransform.position - transform.position;  // sets direction to face player
            up = new Vector2(-direction.y, direction.x) * revolvingDirection;
            up.Normalize();
            up = up*revolvingSpeed;
            up = up * (1f-Time.time*0.0001f);

            transform.position = up + Vector2.MoveTowards(transform.position, targetTransform.position, speed*Time.deltaTime); //moving enemy towards the target (Player)
        }
    }

    // function that makes damage to the enemy
    public void TakeDamage(int damage) {
        Instantiate(destroyParticleEffect, transform.position, Quaternion.identity);
        health -= damage;
    }
}
