using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletVelocity;    // velocity of the bullet
    
    public float lifeTime;           // time after bullet despawns
    public int damage;                  // damage of the bullet

    public float raycastDistance;   // distance of the raycast from the bullet
    public float raycastRadius;      // radius of the raycast from the bullet
    public LayerMask whatIsSolid;           // defines layers that are considered solid for bullet

    private bool inGame;
    private float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        inGame = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().inGame;
        gameSpeed = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().gameSpeed;        
        if(!inGame) {
            bulletVelocity = 200f;
        }
        else {
            bulletVelocity = bulletVelocity + 5f*gameSpeed;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if(inGame) {
            if(transform.position.x > 36 || transform.position.x < -36) {
                Destroy(gameObject);
            }
            else if (transform.position.y > 20.3 || transform.position.y < -20.3) {
                Destroy(gameObject);
            }
        }

        if(lifeTime <= 0) {
            Destroy(gameObject);
        }
        else {
            lifeTime -= Time.deltaTime;
        }

        RaycastHit2D hitInfo = Physics2D.CircleCast(transform.position, raycastRadius, transform.up, raycastDistance, whatIsSolid); // raycasts circle of raycastRadius that collects collision information
        if(hitInfo.collider != null) {  // if there was collision
            if(hitInfo.collider.CompareTag("EnemyRectangle")) {  // and with an object tagged "Enemy"
                hitInfo.collider.GetComponent<EnemyRectangleController>().TakeDamage(damage);    // get that object script and use TakeDamage function (make damage to the enemy)
            } 
            else if(hitInfo.collider.CompareTag("EnemyWave")) {
                hitInfo.collider.GetComponent<EnemyWaveController>().TakeDamage(damage);    // get that object script and use TakeDamage function (make damage to the enemy)
            }
            else if(hitInfo.collider.CompareTag("EnemyCircle")) {
                hitInfo.collider.GetComponent<EnemyCircleController>().TakeDamage(damage);    // get that object script and use TakeDamage function (make damage to the enemy)
            }
            Destroy(gameObject);    // destroy projectile function
        }

        transform.Translate(Vector2.up * bulletVelocity * Time.deltaTime);  // move bullet 
    }
}
