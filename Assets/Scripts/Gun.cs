using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;   // variable holding the bullet GameObject
    public Transform shotPoint; // variable holding GameObject that defines the shot point

    public float startShotCooldown; // time between shots
    private float shotCooldown;
    private float gameSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().gameSpeed;
        shotCooldown = startShotCooldown - gameSpeed*0.05f;
    }


    // Update is called once per frame
    void Update()
    {   
        gameSpeed = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().gameSpeed;

        // - - - Shooting controlls - - - //
        if(shotCooldown <= 0) { // checking if player can shot
            // shooting (space)
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) {
                Instantiate(bullet, shotPoint.position, transform.parent.rotation); // spawns bullet at shot point position with player rotation
                shotCooldown = startShotCooldown - gameSpeed*0.03f;   // resets shot cooldown
                GetComponent<GunShotAnimation>().GunAnim();
            }
        }
        else {
            shotCooldown -= Time.deltaTime; // count down shot cooldown
        }
    }
}
