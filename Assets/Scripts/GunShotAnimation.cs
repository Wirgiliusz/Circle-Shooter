using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotAnimation : MonoBehaviour
{
    public Animator gunAnim;


    public void GunAnim() {
        gunAnim.SetTrigger("shot");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
